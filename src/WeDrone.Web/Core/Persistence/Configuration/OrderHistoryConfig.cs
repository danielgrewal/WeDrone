using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Core.Persistence.Configuration
{
    public class OrderHistoryConfig : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder
                .Property(h => h.Distance)
                .HasColumnType("decimal(10,2)");

            builder
                .HasOne(h => h.From)
                .WithMany(l => l.FromHistory)
                .HasForeignKey(h => h.FromId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.To)
                .WithMany(l => l.ToHistory)
                .HasForeignKey(h => h.ToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasKey(h => new { h.Orderid, h.ValidFrom });
        }
    }
}
