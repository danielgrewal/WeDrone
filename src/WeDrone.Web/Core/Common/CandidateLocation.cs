namespace WeDrone.Web.Core.Common
{
    public class CandidateLocation
    {
        public CandidateLocation(string name, string address, double latitude, double longitude)
        {
            Name = name;
            Address = address;
            Latitude = (decimal)latitude;
            Longitude = (decimal)longitude;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
