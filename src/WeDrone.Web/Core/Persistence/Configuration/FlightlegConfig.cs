using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Core.Persistence.Configuration
{
    public class FlightlegConfig : IEntityTypeConfiguration<Flightleg>
    {
        public void Configure(EntityTypeBuilder<Flightleg> builder)
        {
            builder
                .Property(f => f.Distance)
                .HasColumnType("decimal(10,2)");

            builder
                .HasOne(f => f.From)
                .WithMany(l => l.FromFlightlegs)
                .HasForeignKey(f => f.FromId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.To)
                .WithMany(l => l.ToFlightlegs)
                .HasForeignKey(f => f.ToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Flightleg { FlightlegId = 1, FromId = 1, ToId = 2, Distance = 9.98 },
                new Flightleg { FlightlegId = 2, FromId = 2, ToId = 1, Distance = 9.98 },
                new Flightleg { FlightlegId = 3, FromId = 1, ToId = 3, Distance = 17.43 },
                new Flightleg { FlightlegId = 4, FromId = 3, ToId = 1, Distance = 17.43 },
                new Flightleg { FlightlegId = 5, FromId = 1, ToId = 4, Distance = 19.77 },
                new Flightleg { FlightlegId = 6, FromId = 4, ToId = 1, Distance = 19.77 },
                new Flightleg { FlightlegId = 7, FromId = 1, ToId = 5, Distance = 23.48 },
                new Flightleg { FlightlegId = 8, FromId = 5, ToId = 1, Distance = 23.48 },
                new Flightleg { FlightlegId = 9, FromId = 1, ToId = 6, Distance = 38.95 },
                new Flightleg { FlightlegId = 10, FromId = 6, ToId = 1, Distance = 38.95 },
                new Flightleg { FlightlegId = 11, FromId = 1, ToId = 7, Distance = 65.47 },
                new Flightleg { FlightlegId = 12, FromId = 7, ToId = 1, Distance = 65.47 },
                new Flightleg { FlightlegId = 13, FromId = 2, ToId = 3, Distance = 27.13 },
                new Flightleg { FlightlegId = 14, FromId = 3, ToId = 2, Distance = 27.13 },
                new Flightleg { FlightlegId = 15, FromId = 2, ToId = 4, Distance = 21.24 },
                new Flightleg { FlightlegId = 16, FromId = 4, ToId = 2, Distance = 21.24 },
                new Flightleg { FlightlegId = 17, FromId = 2, ToId = 5, Distance = 28.02 },
                new Flightleg { FlightlegId = 18, FromId = 5, ToId = 2, Distance = 28.02 },
                new Flightleg { FlightlegId = 19, FromId = 2, ToId = 6, Distance = 44.85 },
                new Flightleg { FlightlegId = 20, FromId = 6, ToId = 2, Distance = 44.85 },
                new Flightleg { FlightlegId = 21, FromId = 2, ToId = 7, Distance = 71.51 },
                new Flightleg { FlightlegId = 22, FromId = 7, ToId = 2, Distance = 71.51 },
                new Flightleg { FlightlegId = 23, FromId = 3, ToId = 4, Distance = 23.67 },
                new Flightleg { FlightlegId = 24, FromId = 4, ToId = 3, Distance = 23.67 },
                new Flightleg { FlightlegId = 25, FromId = 3, ToId = 5, Distance = 20.05 },
                new Flightleg { FlightlegId = 26, FromId = 5, ToId = 3, Distance = 20.05 },
                new Flightleg { FlightlegId = 27, FromId = 3, ToId = 6, Distance = 28.64 },
                new Flightleg { FlightlegId = 28, FromId = 6, ToId = 3, Distance = 28.64 },
                new Flightleg { FlightlegId = 29, FromId = 3, ToId = 7, Distance = 53.11 },
                new Flightleg { FlightlegId = 30, FromId = 7, ToId = 3, Distance = 53.11 },
                new Flightleg { FlightlegId = 31, FromId = 4, ToId = 5, Distance = 9.15 },
                new Flightleg { FlightlegId = 32, FromId = 5, ToId = 4, Distance = 9.15 },
                new Flightleg { FlightlegId = 33, FromId = 4, ToId = 6, Distance = 25.81 },
                new Flightleg { FlightlegId = 34, FromId = 6, ToId = 4, Distance = 25.81 },
                new Flightleg { FlightlegId = 35, FromId = 4, ToId = 7, Distance = 51.80 },
                new Flightleg { FlightlegId = 36, FromId = 7, ToId = 4, Distance = 51.80 },
                new Flightleg { FlightlegId = 37, FromId = 5, ToId = 6, Distance = 17.11 },
                new Flightleg { FlightlegId = 38, FromId = 6, ToId = 5, Distance = 17.11 },
                new Flightleg { FlightlegId = 39, FromId = 5, ToId = 7, Distance = 43.60 },
                new Flightleg { FlightlegId = 40, FromId = 7, ToId = 5, Distance = 43.60 },
                new Flightleg { FlightlegId = 41, FromId = 6, ToId = 7, Distance = 26.68 },
                new Flightleg { FlightlegId = 42, FromId = 7, ToId = 6, Distance = 26.68 }
            );

        }
    }
}
