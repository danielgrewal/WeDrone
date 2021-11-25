namespace WeDrone.Web.Core.Domain
{
    public class FlightRoute
    {
        protected FlightRoute()
        {
            this.Orders = new List<Order>();
        }

        public int FlightRouteId { get; set; }
        public int RouteStartId { get; set; }
        public int RouteEndId { get; set; }

        public virtual Location RouteStart  { get; set; }
        public virtual Location RouteEnd { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
