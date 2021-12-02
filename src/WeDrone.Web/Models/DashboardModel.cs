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
            OrdersWithWeightOver10 = context.VwOrdersWithWeightOver10.Count();
            OrdersWithVolumeOver1 = context.VwOrdersWithVolumeOver1.Count();
            FacilityNodes = context.VwShowFacilityNodes.ToList();
            FlightLegsLessThan10 = context.VwFlightLegsLessThan10.ToList();
            OrdersDelivered = context.VwOrdersDelivered.First().OrdersDelivered;

        }

        public int CustomersWithFilledOrders { get; set; }
        public int OrdersWithWeightOver10 { get; set; }
        public int OrdersWithVolumeOver1 { get; set; }
        public int OrdersDelivered { get; set; }
        public List<VwOrder> Orders { get; set; } = new List<VwOrder>();
        public List<VwSubmittedOrders> SubmittedOrders { get; set; } = new List<VwSubmittedOrders>();
        public List<VwAllUsersAndTheirOrders> AllUsersAndTheirOrders { get; set; } = new List<VwAllUsersAndTheirOrders>();
        public List<VwShowFacilityNodes> FacilityNodes { get; set; } = new List<VwShowFacilityNodes>();
        public List<VwFlightLegsLessThan10> FlightLegsLessThan10 { get; set; }
    }
}
