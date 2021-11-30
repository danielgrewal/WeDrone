using System.Text.Json;
using System.Web;
using WeDrone.Web.Core.Interfaces;

namespace WeDrone.Web.Core.Infrastructure.Google
{
    public class APIClient
    {
        private readonly string APIKey;

        public APIClient(string key)
        {
            this.APIKey = key;
        }

        public string GetAddressQueryURI(string query, bool includeGeometry)
        {
            //URL encode query
            string urlEncodedQuery = HttpUtility.UrlPathEncode(query.Trim());

            if (String.IsNullOrEmpty(urlEncodedQuery))
                return null;

            //build URL string for API call
            //string baseURI = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json";
            //string queryString = "?input={0}&inputtype=textquery&fields=formatted_address,geometry&key={1}";
            //string url = String.Format(baseURI + queryString, urlEncodedQuery, this.APIKey);

            string baseURI = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json";
            string inputString = "?input={0}&inputtype=textquery&fields=formatted_address";
            if (includeGeometry)
                inputString += ",geometry,name";
            string keyString = "&key={1}";
            string url = String.Format(baseURI + inputString + keyString, urlEncodedQuery, this.APIKey);

            return url;
        }

        public string GetAutocompleteQueryURI(string query)
        {
            //URL encode query
            string urlEncodedQuery = HttpUtility.UrlPathEncode(query.Trim());

            if (String.IsNullOrEmpty(urlEncodedQuery))
                return null;

            //build URL string for API call
            string baseURI = "https://maps.googleapis.com/maps/api/place/autocomplete/json";
            string queryString = "?input={0}&location=43.71718%2C-79.38704&radius=50000&strictbounds=true&fields=place_id&key={1}";
            string url = String.Format(baseURI + queryString, urlEncodedQuery, this.APIKey);

            return url;
        }

        public async Task<AddressResponse> GetAddress(string query, bool includeGeometry)
        {
            string url = this.GetAddressQueryURI(query, includeGeometry);

            if (String.IsNullOrEmpty(url))
                return null;

            using (var client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                return JsonSerializer.Deserialize<AddressResponse>(response);
            }
        }

        public async Task<PredictionResponse> GetPredictions(string query)
        {
            string url = this.GetAutocompleteQueryURI(query);

            if (String.IsNullOrEmpty(url))
                return null;

            using (var client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                return JsonSerializer.Deserialize<PredictionResponse>(response);
            }
        }
    }
}
