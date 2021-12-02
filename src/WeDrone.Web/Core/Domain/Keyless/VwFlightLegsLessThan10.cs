namespace WeDrone.Web.Core.Domain.Keyless
{
    public class VwFlightLegsLessThan10
    {
        public int FlightlegId { get; set; }
        public int FromId { get; set; }
        public string FromAddress { get; set; }
        public int ToId { get; set; }
        public string ToAddress { get; set; }
        public decimal Distance { get; set; }

    }
}
