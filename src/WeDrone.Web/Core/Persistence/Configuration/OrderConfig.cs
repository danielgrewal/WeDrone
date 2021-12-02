using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Core.Persistence.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(o => o.Weight)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(o => o.Volume)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(o => o.Cost)
                .HasColumnType("decimal(10,2)");

            builder
                .HasOne(o => o.Origin)
                .WithMany(l => l.OriginOrders)
                .HasForeignKey(o => o.OriginId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(o => o.Destination)
                .WithMany(l => l.DestinationOrders)
                .HasForeignKey(o => o.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
