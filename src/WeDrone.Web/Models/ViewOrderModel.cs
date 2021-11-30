using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Models
{
    public class ViewOrderModel
    {
        public ViewOrderModel(Order order, User user, Location origin, Location destination, List<OrderHistory> orderHistory)
        {
            this.Order = order;
            this.User = user;
            this.Origin = origin;
            this.Destination = destination;
            this.OrderHistory = orderHistory;
        }

        public Order Order { get; set; }
        public User User { get; set; }
        public Location Origin { get; set; }
        public Location Destination { get; set; }
        public List<OrderHistory> OrderHistory { get; set; }
    }
}
