using WeDrone.Web.Core.Infrastructure.Google;
using WeDrone.Web.Core.Interfaces;

namespace WeDrone.Web.Core.Infrastructure
{
    public class AddressLookup : IAddressLookup
    {
        private readonly APIClient client;

        public AddressLookup(APIClient client)
        {
            this.client = client;
        }

        public async Task<List<string>> Find(string query)
        {
            var response = await client.GetPredictions(query);
            List<string> addresses = response.predictions.Select(x => x.description).ToList();

            return addresses;
        }
    }
}
