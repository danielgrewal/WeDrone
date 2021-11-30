using System.ComponentModel.DataAnnotations;
using WeDrone.Web.Core.Common;
using WeDrone.Web.Core.Domain;
using WeDrone.Web.Core.Interfaces;
using WeDrone.Web.Core.Persistence;

namespace WeDrone.Web.Models
{
    public class CreateOrderModel
    {

        [Required]
        public double Length { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public string PickupAddress { get; set; }
        [Required]
        public string DropoffAddress { get; set; }

        public async Task<Result<Location>> GetLocation(WeDroneContext context, IAddressLookup addressFinder, string address)
        {
            // Get location details from Google API
            var result = await addressFinder.GetCandidateLocation(address);

            if (!result.IsSuccess)
                return Result<Location>.Fail(result.FailureReason);

            var candidate = result.Payload;

            // Check if location is already in the database and add if not found
            var location = context.Locations.FirstOrDefault(l => l.Address == candidate.Address);
            if (location == null)
            {
                location = new Location(candidate.Name, candidate.Address, candidate.Latitude, candidate.Longitude);
                context.Locations.Add(location);
                context.SaveChanges();
            }

            return Result<Location>.Success(location);
        }

        public Order CreateOrder(WeDroneContext context, DroneOptions options, 
            List<Flightleg> flightPlan, int? flightRouteId, string username)
        {
            var user = context.Users.FirstOrDefault(u => u.Username == username);
            var now = DateTime.Now;
            var order = new Order
            {
                UserId = user.UserId,
                OriginId = flightPlan.First().ToId,
                DestinationId = flightPlan.Last().ToId,
                FlightRouteId = flightRouteId,
                Weight = Weight,
                Volume = Length * Width * Height,
                Cost = options.Rate * flightPlan.Sum(fp => fp.Distance),
                OrderCreated = now,
            };

            var timeReference = now;
            var i = 0;
            foreach(var leg in flightPlan)
            {
                int status;
                if (i == 0)
                    status = 1;
                else if (i == 1)
                    status = 2;
                //else if (i == 1 && flightRouteId != null)
                //    status = 2;
                //else if (i == 1 && flightRouteId == null)
                //    status = 4;
                else
                    status = 3;

                var validTo = timeReference.AddSeconds(leg.Distance / options.Speed);
                var historyEntry = new OrderHistory
                {
                    ValidFrom = timeReference,
                    ValidTo = validTo,
                    FromId = leg.FromId,
                    ToId = leg.ToId,
                    StatusId = status,
                    Distance = leg.Distance

                };
                order.HistoryEntries.Add(historyEntry);
                timeReference = validTo;
                i++;
            }
            order.HistoryEntries.Last().StatusId = 4;
            var deliveredEntry = new OrderHistory
            {
                ValidFrom = timeReference,
                ValidTo = new DateTime(9999, 12, 31),
                FromId = null,
                ToId = null,
                StatusId = 5,
                Distance = null
            };
            order.HistoryEntries.Add(deliveredEntry);
            order.OrderFilled = timeReference;
            context.Add(order);
            context.SaveChanges();

            return order;
        }

    }
}
