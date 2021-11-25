using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Core.Persistence.Configuration
{
    public class FlightRouteConfig : IEntityTypeConfiguration<FlightRoute>
    {
        public void Configure(EntityTypeBuilder<FlightRoute> builder)
        {
            builder
                .HasOne(f => f.RouteStart)
                .WithMany(l => l.StartFlightRoutes)
                .HasForeignKey(f => f.RouteStartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.RouteEnd)
                .WithMany(l => l.EndFlightRoutes)
                .HasForeignKey(f => f.RouteEndId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
