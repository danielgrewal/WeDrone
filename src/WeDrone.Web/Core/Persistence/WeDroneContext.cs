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
        public DbSet<VwSubmittedOrders> VwSubmittedOrders { get; set; }
        public DbSet<VwCustomersWithFilledOrders> VwCustomersWithFilledOrders { get; set; }
        public DbSet<VwAllUsersAndTheirOrders> VwAllUsersAndTheirOrders { get; set; }
        public DbSet<VwOrdersWithWeightOver10> VwOrdersWithWeightOver10 { get; set; }
        public DbSet<VwOrdersWithVolumeOver1> VwOrdersWithVolumeOver1 { get; set; }
        public DbSet<VwShowFacilityNodes> VwShowFacilityNodes { get; set; }
        public DbSet<VwFlightLegsLessThan10> VwFlightLegsLessThan10 { get; set; }
        public DbSet<VwOrdersDelivered> VwOrdersDelivered { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(WeDroneContext).Assembly);
            builder.Entity<VwOrder>().ToView("vw_ShowAllOrders").HasKey(o => o.OrderId);
            builder.Entity<VwSubmittedOrders>().ToView("vw_OrdersWithDistanceNotCancelled").HasKey(o => o.OrderId);
            builder.Entity<VwCustomersWithFilledOrders>().ToView("vw_CustomersWithFilledOrders").HasKey(o => o.UserId);
            builder.Entity<VwAllUsersAndTheirOrders>().ToView("vw_AllUsersAndTheirOrders").HasNoKey();
            builder.Entity<VwOrdersWithWeightOver10>().ToView("vw_OrdersWithWeightOver10").HasKey(o => o.OrderId);
            builder.Entity<VwOrdersWithVolumeOver1>().ToView("vw_OrdersWithVolumeOver1").HasKey(o => o.OrderId);
            builder.Entity<VwShowFacilityNodes>().ToView("vw_ShowFacilityNodes").HasKey(l => l.LocationId);
            builder.Entity<VwFlightLegsLessThan10>().ToView("vw_FlightLegsLessThan10").HasKey(fl => fl.FlightlegId);
            builder.Entity<VwOrdersDelivered>().ToView("vw_OrdersDelivered").HasNoKey();

            base.OnModelCreating(builder);
        }
    }
}
