namespace WeDrone.Web.Core.Domain.Keyless
{
    public class VwShowFacilityNodes
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; } 
        public string Address { get; set; }
        public bool IsDroneFacility { get; set; }
    }
}
