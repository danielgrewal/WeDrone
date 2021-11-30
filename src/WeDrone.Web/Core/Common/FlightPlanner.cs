using Microsoft.EntityFrameworkCore;
using WeDrone.Web.Core.Domain;
using WeDrone.Web.Core.Persistence;

namespace WeDrone.Web.Core.Common
{
    public class FlightPlanner
    {
        private readonly WeDroneContext _context;
        private readonly DroneOptions _options;
        private readonly Location _origin;
        private readonly Location _destination;
        private readonly List<Location> _nodes;
        
        public FlightPlanner(WeDroneContext context, DroneOptions options, Location origin, Location destination)
        {
            _context = context;
            _options = options;
            _origin = origin;
            _destination = destination;
            _nodes = _context.Locations.Where(l => l.IsDroneFacility == true).ToList();
        }

        public int? FlightRouteId { get; set; }

        public Result<List<Flightleg>> GetFlightPlan()
        {
            var initialLegResult = GetInitialLeg(_origin);
            if (!initialLegResult.IsSuccess)
                return Result<List<Flightleg>>.Fail(initialLegResult.FailureReason);

            var finalLegResult = GetFinalLeg(_destination);
            if (!finalLegResult.IsSuccess)
                return Result<List<Flightleg>>.Fail(finalLegResult.FailureReason);

            var initialLeg = initialLegResult.Payload;
            var finalLeg = finalLegResult.Payload;

            // Deliver through direcet route if viable
            var directRoute = GetDirectRoute(initialLeg);
            if (directRoute != null)
                return Result<List<Flightleg>>.Success(directRoute);

            // Pick-up package and return to node
            var flightPlan = new List<Flightleg>();
            flightPlan.Add(initialLeg);
            flightPlan.Add(Invert(initialLeg));

            // Is the same node closest to both addresses
            if (initialLeg.FromId != finalLeg.FromId)
            {
                var flightRoute = _context.Flightlegs.FromSqlRaw("EXEC dbo.sp_GetFlightPlan {0}, {1}", initialLeg.FromId, finalLeg.FromId);
                flightPlan.AddRange(flightRoute);
                this.FlightRouteId = _context.FlightRoutes.FirstOrDefault(
                    fr => fr.RouteStartId == initialLeg.FromId && fr.RouteEndId == finalLeg.FromId).FlightRouteId;
            }

            // Drop-off package
            flightPlan.Add(finalLeg);

            return Result<List<Flightleg>>.Success(flightPlan);
        }

        public List<Flightleg> GetDirectRoute(Flightleg initialLeg)
        {
            var originNode = _context.Locations.FirstOrDefault(l => l.LocationId == initialLeg.FromId);

            var initialLegDistance = initialLeg.Distance;
            var directDeliveryDistance = FlightPlanner.GetDistance(_origin, _destination);
            var directDeliveryReturnDistance = FlightPlanner.GetDistance(_destination, originNode);

            if ((initialLegDistance + directDeliveryDistance + directDeliveryReturnDistance) < _options.MaxDistance)
            {
                var flightPlan = new List<Flightleg>();
                flightPlan.Add(initialLeg);
                flightPlan.Add(new Flightleg(_origin, _destination, directDeliveryDistance));
                //flightPlan.Add(new Flightleg(_destination, originNode, directDeliveryReturnDistance));
                return flightPlan;
            }

            return null;
        }

        public Flightleg Invert(Flightleg flightleg)
        {
            var inverted = new Flightleg();
            inverted.FromId = flightleg.ToId;
            inverted.ToId = flightleg.FromId;
            inverted.Distance = flightleg.Distance;
            return inverted;
        }

        public Result<Flightleg> GetInitialLeg(Location pickupLocation)
        {
            double minDistance = 9999;
            Flightleg initialLeg = new Flightleg();
            foreach (var node in _nodes)
            {
                var nodeDistance = GetDistance(node, pickupLocation);
                if (nodeDistance < minDistance)
                {
                    minDistance = nodeDistance;
                    initialLeg = new Flightleg(node, pickupLocation, nodeDistance);
                }   
            }

            // Divide by 2 since the drone has to return with the package as well.
            if (minDistance > (_options.MaxDistance / 2))
                return Result<Flightleg>.Fail("The pick-up location is too far away.");

            return Result<Flightleg>.Success(initialLeg);
        }

        public Result<Flightleg> GetFinalLeg(Location dropoffLocation)
        {
            double minDistance = 9999;
            Flightleg finalLeg = new Flightleg();
            foreach (var node in _nodes)
            {
                var nodeDistance = GetDistance(node, dropoffLocation);
                if (nodeDistance < minDistance)
                {
                    minDistance = nodeDistance;
                    finalLeg = new Flightleg(node, dropoffLocation, nodeDistance);
                }
            }

            // Divide by 2 since the drone has to return with the package as well.
            if (minDistance > (_options.MaxDistance / 2))
                return Result<Flightleg>.Fail("The drop-off location is too far away.");

            return Result<Flightleg>.Success(finalLeg);
        }

        public static double GetDistance(Location loc1, Location loc2)
        {
            var lat1 = decimal.ToDouble(loc1.Latitude);
            var lng1 = decimal.ToDouble(loc1.Longitude);
            var lat2 = decimal.ToDouble(loc2.Latitude);
            var lng2 = decimal.ToDouble(loc2.Longitude);

            return Utilities.Haversine(lat1, lng1, lat2, lng2);
        }
    }
}
