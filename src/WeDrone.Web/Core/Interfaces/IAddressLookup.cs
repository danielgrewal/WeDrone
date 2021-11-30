using WeDrone.Web.Core.Common;

namespace WeDrone.Web.Core.Interfaces
{
    public interface IAddressLookup
    {
        Task<List<string>> Find(string query);
        Task<Result<CandidateLocation>> GetCandidateLocation(string address);
    }
}
