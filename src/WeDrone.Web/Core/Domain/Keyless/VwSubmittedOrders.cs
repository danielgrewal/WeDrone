namespace WeDrone.Web.Core.Domain.Keyless
{
    public class VwSubmittedOrders
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public int? FlightRouteId { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public decimal Cost { get; set; }
        public DateTime OrderCreated { get; set; }
        public DateTime OrderFilled { get; set; }
        public decimal Distance { get; set; }

    }
}
