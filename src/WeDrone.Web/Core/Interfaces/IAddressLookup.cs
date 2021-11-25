namespace WeDrone.Web.Core.Interfaces
{
    public interface IAddressLookup
    {
        Task<List<string>> Find(string query);
    }
}
