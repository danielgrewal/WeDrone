using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Models
{
    public class ViewOrderModel
    {
        public ViewOrderModel(Order order, List<OrderHistory> orderHistory)
        {
            this.Order = order;
            this.User = order.User;
            this.Origin = order.Origin;
            this.Destination = order.Destination;
            this.OrderHistory = orderHistory;
        }

        public Order Order { get; set; }
        public User User { get; set; }
        public Location Origin { get; set; }
        public Location Destination { get; set; }
        public List<OrderHistory> OrderHistory { get; set; }
    }
}
