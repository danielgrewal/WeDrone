using WeDrone.Web.Core.Domain.Keyless;

namespace WeDrone.Web.Models
{
    public class DashboardModel
    {
        public DashboardModel()
        {
            var Orders = new List<VwOrder>();
        }

        public DashboardModel(List<VwOrder> orders)
        {
            Orders = orders;
        }

        public List<VwOrder> Orders { get; set; }

    }
}
