using System.Text.Json;
using System.Web;
using WeDrone.Web.Core.Interfaces;

namespace WeDrone.Web.Core.Infrastructure.Google
{
    public class APIClient : IAddressLookup
    {
        private readonly string APIKey;

        public APIClient(string key)
        {
            this.APIKey = key;
        }

        public string GetQueryURI(string query)
        {
            //URL encode query
            string urlEncodedQuery = HttpUtility.UrlPathEncode(query.Trim());

            if (String.IsNullOrEmpty(urlEncodedQuery))
                return null;

            //build URL string for API call
            string baseURI = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json";
            string queryString = "?input={0}&inputtype=textquery&fields=formatted_address,place_id&key={1}";
            string url = String.Format(baseURI + queryString, urlEncodedQuery, this.APIKey);

            return url;
        }

        public async Task<AddressResponse> GetAddresses(string query)
        {
            string url = this.GetQueryURI(query);

            if (String.IsNullOrEmpty(url))
                return null;

            using (var client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                return JsonSerializer.Deserialize<AddressResponse>(response);
            }
        }
    }
}
