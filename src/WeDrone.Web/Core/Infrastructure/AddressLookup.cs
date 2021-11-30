using WeDrone.Web.Core.Common;
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

        public async Task<Result<CandidateLocation>> GetCandidateLocation(string address)
        {
            var response = await client.GetAddress(address, true);

            if (response.status != "OK")
            {
                if (response.status == "ZERO_RESULTS")
                    return Result<CandidateLocation>.Fail("No locations found.");

                return Result<CandidateLocation>.Fail("Oops! Something went wrong. Cannot access external API.");
            }    

            var topCandidate = response.candidates.FirstOrDefault();

            var candidateLocation = new CandidateLocation(
                topCandidate.name, topCandidate.formatted_address, 
                topCandidate.geometry.location.lat, 
                topCandidate.geometry.location.lng);

            return Result<CandidateLocation>.Success(candidateLocation);
        }
    }
}
