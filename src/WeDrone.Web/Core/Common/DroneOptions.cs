namespace WeDrone.Web.Core.Common
{
    public class DroneOptions
    {
        public const string DroneSettings = "DroneSettings";

        public double MaxVolume { get; set; }
        public double MaxWeight { get; set; }
        public double MaxDistance { get; set; }
        public double Speed { get; set; }
        public double Rate { get; set; }
    }
}
