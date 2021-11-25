using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Core.Persistence.Configuration
{
    public class FlightRouteStepConfig : IEntityTypeConfiguration<FlightRouteStep>
    {
        public void Configure(EntityTypeBuilder<FlightRouteStep> builder)
        {
            builder
                .HasOne(frs => frs.CurrentLeg)
                .WithMany(fl => fl.CurrentLegSteps)
                .HasForeignKey(frs => frs.CurrentLegId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(frs => frs.NextLeg)
                .WithMany(fl => fl.NextlegSteps)
                .HasForeignKey(frs => frs.NextLegId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasKey(frs => new { frs.FlightRouteId, frs.CurrentLegId });
        }
    }
}
