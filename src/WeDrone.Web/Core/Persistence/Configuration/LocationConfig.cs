using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Core.Persistence.Configuration
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .Property(l => l.Name)
                .HasMaxLength(255);

            builder
                .Property(l => l.Latitude)
                .HasColumnType("decimal(17,14)");

            builder
                .Property(l => l.Longitude)
                .HasColumnType("decimal(17,14)");

            builder
                .Property(l => l.Address)
                .HasMaxLength(255);
        }
    }
}
