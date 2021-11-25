﻿using Microsoft.EntityFrameworkCore;
using WeDrone.Web.Core.Domain;

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
        public DbSet<FlightRouteStep> FlightRouteStep { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(WeDroneContext).Assembly);
            //builder.Entity<Location>().HasNoKey().ToView(null);

            base.OnModelCreating(builder);
        }
    }
}
