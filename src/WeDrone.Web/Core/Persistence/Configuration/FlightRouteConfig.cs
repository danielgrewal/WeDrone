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

            builder.HasData(
                new FlightRoute { FlightRouteId = 1, RouteStartId = 1, RouteEndId = 2 },
                new FlightRoute { FlightRouteId = 2, RouteStartId = 2, RouteEndId = 1 },
                new FlightRoute { FlightRouteId = 3, RouteStartId = 1, RouteEndId = 3 },
                new FlightRoute { FlightRouteId = 4, RouteStartId = 3, RouteEndId = 1 },
                new FlightRoute { FlightRouteId = 5, RouteStartId = 1, RouteEndId = 4 },
                new FlightRoute { FlightRouteId = 6, RouteStartId = 4, RouteEndId = 1 },
                new FlightRoute { FlightRouteId = 7, RouteStartId = 1, RouteEndId = 5 },
                new FlightRoute { FlightRouteId = 8, RouteStartId = 5, RouteEndId = 1 },
                new FlightRoute { FlightRouteId = 9, RouteStartId = 1, RouteEndId = 6 },
                new FlightRoute { FlightRouteId = 10, RouteStartId = 6, RouteEndId = 1 },
                new FlightRoute { FlightRouteId = 11, RouteStartId = 1, RouteEndId = 7 },
                new FlightRoute { FlightRouteId = 12, RouteStartId = 7, RouteEndId = 1 },
                new FlightRoute { FlightRouteId = 13, RouteStartId = 2, RouteEndId = 3 },
                new FlightRoute { FlightRouteId = 14, RouteStartId = 3, RouteEndId = 2 },
                new FlightRoute { FlightRouteId = 15, RouteStartId = 2, RouteEndId = 4 },
                new FlightRoute { FlightRouteId = 16, RouteStartId = 4, RouteEndId = 2 },
                new FlightRoute { FlightRouteId = 17, RouteStartId = 2, RouteEndId = 5 },
                new FlightRoute { FlightRouteId = 18, RouteStartId = 5, RouteEndId = 2 },
                new FlightRoute { FlightRouteId = 19, RouteStartId = 2, RouteEndId = 6 },
                new FlightRoute { FlightRouteId = 20, RouteStartId = 6, RouteEndId = 2 },
                new FlightRoute { FlightRouteId = 21, RouteStartId = 2, RouteEndId = 7 },
                new FlightRoute { FlightRouteId = 22, RouteStartId = 7, RouteEndId = 2 },
                new FlightRoute { FlightRouteId = 23, RouteStartId = 3, RouteEndId = 4 },
                new FlightRoute { FlightRouteId = 24, RouteStartId = 4, RouteEndId = 3 },
                new FlightRoute { FlightRouteId = 25, RouteStartId = 3, RouteEndId = 5 },
                new FlightRoute { FlightRouteId = 26, RouteStartId = 5, RouteEndId = 3 },
                new FlightRoute { FlightRouteId = 27, RouteStartId = 3, RouteEndId = 6 },
                new FlightRoute { FlightRouteId = 28, RouteStartId = 6, RouteEndId = 3 },
                new FlightRoute { FlightRouteId = 29, RouteStartId = 3, RouteEndId = 7 },
                new FlightRoute { FlightRouteId = 30, RouteStartId = 7, RouteEndId = 3 },
                new FlightRoute { FlightRouteId = 31, RouteStartId = 4, RouteEndId = 5 },
                new FlightRoute { FlightRouteId = 32, RouteStartId = 5, RouteEndId = 4 },
                new FlightRoute { FlightRouteId = 33, RouteStartId = 4, RouteEndId = 6 },
                new FlightRoute { FlightRouteId = 34, RouteStartId = 6, RouteEndId = 4 },
                new FlightRoute { FlightRouteId = 35, RouteStartId = 4, RouteEndId = 7 },
                new FlightRoute { FlightRouteId = 36, RouteStartId = 7, RouteEndId = 4 },
                new FlightRoute { FlightRouteId = 37, RouteStartId = 5, RouteEndId = 6 },
                new FlightRoute { FlightRouteId = 38, RouteStartId = 6, RouteEndId = 5 },
                new FlightRoute { FlightRouteId = 39, RouteStartId = 5, RouteEndId = 7 },
                new FlightRoute { FlightRouteId = 40, RouteStartId = 7, RouteEndId = 5 },
                new FlightRoute { FlightRouteId = 41, RouteStartId = 6, RouteEndId = 7 },
                new FlightRoute { FlightRouteId = 42, RouteStartId = 7, RouteEndId = 6 }
            );

        }
    }
}
