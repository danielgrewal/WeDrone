namespace WeDrone.Web.Core.Domain.Keyless
{
    public class VwAllUsersAndTheirOrders
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? OrderId { get; set; }
        public int? OriginId { get; set; }
        public int? DestinationId { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Volume { get; set; }
        public DateTime? OrderCreated { get; set; }
        public DateTime? OrderFilled { get; set; }
    }
}
