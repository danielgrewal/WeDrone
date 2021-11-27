using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Core.Persistence.Configuration
{
    public class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder
                .Property(s => s.Name)
                .HasMaxLength(50);

            builder.HasData(
                new Status { StatusId = 1, Name = "Pending Pick-up" },
                new Status { StatusId = 2, Name = "Order Retrieved" },
                new Status { StatusId = 3, Name = "In Transit" },
                new Status { StatusId = 4, Name = "Pending Drop-off" },
                new Status { StatusId = 5, Name = "Delivered" },
                new Status { StatusId = 6, Name = "Cancelled" }
            );
        }
    }
}
