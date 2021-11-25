namespace WeDrone.Web.Core.Domain
{
    public class Location
    {
        public Location()
        {
            this.FromFlightlegs = new List<Flightleg>();
            this.ToFlightlegs = new List<Flightleg>();
            this.StartFlightRoutes = new List<FlightRoute>();
            this.EndFlightRoutes = new List<FlightRoute>();
            this.OriginOrders = new List<Order>();
            this.DestinationOrders = new List<Order>();
            this.FromHistory = new List<OrderHistory>();
            this.ToHistory = new List<OrderHistory>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public decimal Latitude {get;set;} // Set scale
        public decimal Longitude { get; set; } // Set scale
        public string Address { get; set; }
        public bool IsDroneFacility { get; set; }

        public virtual ICollection<Flightleg> FromFlightlegs { get; set; }
        public virtual ICollection<Flightleg> ToFlightlegs { get; set; }
        public virtual ICollection<FlightRoute> StartFlightRoutes { get; set; }
        public virtual ICollection<FlightRoute> EndFlightRoutes { get; set; }
        public virtual ICollection<Order> OriginOrders { get; set; }
        public virtual ICollection<Order> DestinationOrders { get; set;}
        public virtual ICollection<OrderHistory> FromHistory { get; set; }
        public virtual ICollection<OrderHistory> ToHistory { get; set; }
    }
}
