namespace WeDrone.Web.Core.Domain
{
    public class FlightRouteStep
    {
        public int FlightRouteId { get; set; }
        public int CurrentLegId { get; set; }
        public int? NextLegId { get; set; }
        public bool IsInitialLeg { get; set; }

        public virtual Flightleg CurrentLeg { get; set; }
        public virtual Flightleg NextLeg { get; set; }
    }
}
