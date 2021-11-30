namespace WeDrone.Web.Core.Domain
{
    public class OrderHistory
    {
        public int Orderid { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public int StatusId { get; set; }
        public double? Distance { get; set; }
        
        public virtual Order Order { get; set; }
        public virtual Location From { get; set; }
        public virtual Location To { get; set; }
        public virtual Status Status { get; set; }
    }
}
