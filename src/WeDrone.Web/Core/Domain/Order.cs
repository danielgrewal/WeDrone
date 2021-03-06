namespace WeDrone.Web.Core.Domain
{
    public class Order
    {
        public Order()
        {
            this.HistoryEntries = new List<OrderHistory>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public int? FlightRouteId { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double Cost { get; set; }
        public DateTime? OrderCreated { get; set; }
        public DateTime? OrderFilled { get; set; }

        public virtual User User { get; set; }
        public virtual Location Origin { get; set; }
        public virtual Location Destination { get; set; }
        public virtual FlightRoute FlightRoute { get; set; }
        public virtual ICollection<OrderHistory> HistoryEntries { get; set; }
    }
}
