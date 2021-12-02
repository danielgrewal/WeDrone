using WeDrone.Web.Core.Domain.Keyless;
using WeDrone.Web.Core.Persistence;

namespace WeDrone.Web.Models
{
    public class DashboardModel
    {

        public DashboardModel(WeDroneContext context)
        {
            Orders = context.VwOrders.ToList();
            SubmittedOrders = context.VwSubmittedOrders.ToList();
            CustomersWithFilledOrders = context.VwCustomersWithFilledOrders.Count();
            AllUsersAndTheirOrders = context.VwAllUsersAndTheirOrders.ToList();
        }

        public int CustomersWithFilledOrders { get; set; }
        public List<VwOrder> Orders { get; set; } = new List<VwOrder>();
        public List<VwSubmittedOrders> SubmittedOrders { get; set; } = new List<VwSubmittedOrders>();
        public List<VwAllUsersAndTheirOrders> AllUsersAndTheirOrders { get; set; } = new List<VwAllUsersAndTheirOrders>();
    }
}
