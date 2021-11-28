namespace WeDrone.Web.Core.Common
{
    public static class Utilities
    {
        public static double Haversine(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371.0710; // In kilometers
            var dLat = toRadians(lat2 - lat1);
            var dLon = toRadians(lon2 - lon1);
            lat1 = toRadians(lat1);
            lat2 = toRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            var distance = R * c;
            return Math.Round(distance, 2);
        }

        public static double toRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
