namespace WeDrone.Web.Core.Domain
{
    public class Flightleg
    {
        public Flightleg()
        {
            this.CurrentLegSteps = new List<FlightRouteStep>();
            this.NextlegSteps = new List<FlightRouteStep>();
        }

        public int FlightlegId { get; set; }
        public int FromId { get; set; }
        public int Toid { get; set; }
        public double Distance { get; set; }

        public virtual Location From { get; set; }
        public virtual Location To { get; set; }
        public virtual ICollection<FlightRouteStep> CurrentLegSteps { get; set; }
        public virtual ICollection<FlightRouteStep> NextlegSteps { get; set; }
    }
}
