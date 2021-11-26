namespace WeDrone.Web.Models
{
    public class CreateOrderModel
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string PickupAddress { get; set; }
        public string DropoffAddress { get; set; }
    }
}
