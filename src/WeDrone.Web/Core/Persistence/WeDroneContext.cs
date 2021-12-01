using Microsoft.EntityFrameworkCore;
using WeDrone.Web.Core.Domain;
using WeDrone.Web.Core.Domain.Keyless;

namespace WeDrone.Web.Core.Persistence
{
    public class WeDroneContext : DbContext
    {
        public WeDroneContext(DbContextOptions<WeDroneContext> options) : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Flightleg> Flightlegs { get; set; }
        public DbSet<FlightRoute> FlightRoutes { get; set; }
        public DbSet<FlightRouteStep> FlightRouteSteps { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }

        // Keyless Entities
        public DbSet<VwOrder> VwOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(WeDroneContext).Assembly);
            builder.Entity<VwOrder>().HasNoKey().ToView("vw_ShowAllOrders").HasKey(o => o.OrderId);

            base.OnModelCreating(builder);
        }
    }
}
