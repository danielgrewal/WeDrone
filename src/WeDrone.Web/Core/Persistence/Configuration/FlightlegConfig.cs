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
                .HasForeignKey(f => f.Toid)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
