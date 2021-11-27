namespace WeDrone.Web.Core.Domain
{
    public class User
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
