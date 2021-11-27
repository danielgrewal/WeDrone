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

            builder.HasData(
                new FlightRouteStep { FlightRouteId = 1, CurrentLegId = 1, NextLegId = null, IsInitialLeg = true },//ROUTE 1(1->2)
                new FlightRouteStep { FlightRouteId = 2, CurrentLegId = 2, NextLegId = null, IsInitialLeg = true },//ROUTE 2(2->1)
                new FlightRouteStep { FlightRouteId = 3, CurrentLegId = 3, NextLegId = null, IsInitialLeg = true },//ROUTE 3(1->3)
                new FlightRouteStep { FlightRouteId = 4, CurrentLegId = 4, NextLegId = null, IsInitialLeg = true },//ROUTE 4(3->1)
                new FlightRouteStep { FlightRouteId = 5, CurrentLegId = 5, NextLegId = null, IsInitialLeg = true },//ROUTE 5(1->4)
                new FlightRouteStep { FlightRouteId = 6, CurrentLegId = 6, NextLegId = null, IsInitialLeg = true },//ROUTE 6(4->1)
                new FlightRouteStep { FlightRouteId = 7, CurrentLegId = 7, NextLegId = null, IsInitialLeg = true },//ROUTE 7(1->5)
                new FlightRouteStep { FlightRouteId = 8, CurrentLegId = 8, NextLegId = null, IsInitialLeg = true },//ROUTE 8(5->1)

                new FlightRouteStep { FlightRouteId = 9, CurrentLegId = 7, NextLegId = 37, IsInitialLeg = true },//ROUTE 9(1->6)
                new FlightRouteStep { FlightRouteId = 9, CurrentLegId = 37, NextLegId = null, IsInitialLeg = false },//ROUTE 9(1->6)

                new FlightRouteStep { FlightRouteId = 10, CurrentLegId = 38, NextLegId = 8, IsInitialLeg = true },//ROUTE 10(6->1)
                new FlightRouteStep { FlightRouteId = 10, CurrentLegId = 8, NextLegId = null, IsInitialLeg = false },//ROUTE 10(6->1)

                new FlightRouteStep { FlightRouteId = 11, CurrentLegId = 7, NextLegId = 37, IsInitialLeg = true },//ROUTE 11(1->7)
                new FlightRouteStep { FlightRouteId = 11, CurrentLegId = 37, NextLegId = 41, IsInitialLeg = false },//ROUTE 11(1->7)
                new FlightRouteStep { FlightRouteId = 11, CurrentLegId = 41, NextLegId = null, IsInitialLeg = false },//ROUTE 11(1->7)

                new FlightRouteStep { FlightRouteId = 12, CurrentLegId = 42, NextLegId = 38, IsInitialLeg = true },//ROUTE 12(7->1)
                new FlightRouteStep { FlightRouteId = 12, CurrentLegId = 38, NextLegId = 8, IsInitialLeg = false },//ROUTE 12(7->1)
                new FlightRouteStep { FlightRouteId = 12, CurrentLegId = 8, NextLegId = null, IsInitialLeg = false },//ROUTE 12(7->1)

                new FlightRouteStep { FlightRouteId = 13, CurrentLegId = 2, NextLegId = 3, IsInitialLeg = true },//ROUTE 13(2->3)
                new FlightRouteStep { FlightRouteId = 13, CurrentLegId = 3, NextLegId = null, IsInitialLeg = false },//ROUTE 13(2->3)

                new FlightRouteStep { FlightRouteId = 14, CurrentLegId = 4, NextLegId = 1, IsInitialLeg = true },//ROUTE 14(3->2)
                new FlightRouteStep { FlightRouteId = 14, CurrentLegId = 1, NextLegId = null, IsInitialLeg = false },//ROUTE 14(3->2)

                new FlightRouteStep { FlightRouteId = 15, CurrentLegId = 15, NextLegId = null, IsInitialLeg = true },//ROUTE 15(2->4)

                new FlightRouteStep { FlightRouteId = 16, CurrentLegId = 16, NextLegId = null, IsInitialLeg = true },//ROUTE 16(4->2)

                new FlightRouteStep { FlightRouteId = 17, CurrentLegId = 15, NextLegId = 31, IsInitialLeg = true },//ROUTE 17(2->5)
                new FlightRouteStep { FlightRouteId = 17, CurrentLegId = 31, NextLegId = null, IsInitialLeg = false },//ROUTE 17(2->5)

                new FlightRouteStep { FlightRouteId = 18, CurrentLegId = 32, NextLegId = 16, IsInitialLeg = true },//ROUTE 18(5->2)
                new FlightRouteStep { FlightRouteId = 18, CurrentLegId = 16, NextLegId = null, IsInitialLeg = false },//ROUTE 18(5->2)

                new FlightRouteStep { FlightRouteId = 19, CurrentLegId = 15, NextLegId = 31, IsInitialLeg = true },//ROUTE 19(2->6)
                new FlightRouteStep { FlightRouteId = 19, CurrentLegId = 31, NextLegId = 37, IsInitialLeg = false },//ROUTE 19(2->6)
                new FlightRouteStep { FlightRouteId = 19, CurrentLegId = 37, NextLegId = null, IsInitialLeg = false },//ROUTE 19(2->6)

                new FlightRouteStep { FlightRouteId = 20, CurrentLegId = 38, NextLegId = 32, IsInitialLeg = true },//ROUTE 20(6->2)
                new FlightRouteStep { FlightRouteId = 20, CurrentLegId = 32, NextLegId = 16, IsInitialLeg = false },//ROUTE 20(6->2)
                new FlightRouteStep { FlightRouteId = 20, CurrentLegId = 16, NextLegId = null, IsInitialLeg = false },//ROUTE 20(6->2)

                new FlightRouteStep { FlightRouteId = 21, CurrentLegId = 15, NextLegId = 31, IsInitialLeg = true },//ROUTE 21(2->7)
                new FlightRouteStep { FlightRouteId = 21, CurrentLegId = 31, NextLegId = 37, IsInitialLeg = false },//ROUTE 21(2->7)
                new FlightRouteStep { FlightRouteId = 21, CurrentLegId = 37, NextLegId = 41, IsInitialLeg = false },//ROUTE 21(2->7)
                new FlightRouteStep { FlightRouteId = 21, CurrentLegId = 41, NextLegId = null, IsInitialLeg = false },//ROUTE 21(2->7)

                new FlightRouteStep { FlightRouteId = 22, CurrentLegId = 42, NextLegId = 38, IsInitialLeg = true },//ROUTE 22(7->2)
                new FlightRouteStep { FlightRouteId = 22, CurrentLegId = 38, NextLegId = 32, IsInitialLeg = false },//ROUTE 22(7->2)
                new FlightRouteStep { FlightRouteId = 22, CurrentLegId = 32, NextLegId = 16, IsInitialLeg = false },//ROUTE 22(7->2)
                new FlightRouteStep { FlightRouteId = 22, CurrentLegId = 16, NextLegId = null, IsInitialLeg = false },//ROUTE 22(7->2)

                new FlightRouteStep { FlightRouteId = 23, CurrentLegId = 7, NextLegId = null, IsInitialLeg = true },//ROUTE 23(3->4)
                new FlightRouteStep { FlightRouteId = 24, CurrentLegId = 8, NextLegId = null, IsInitialLeg = true },//ROUTE 24(4->3)
                new FlightRouteStep { FlightRouteId = 25, CurrentLegId = 25, NextLegId = null, IsInitialLeg = true },//ROUTE 25(3->5)
                new FlightRouteStep { FlightRouteId = 26, CurrentLegId = 26, NextLegId = null, IsInitialLeg = true },//ROUTE 26(5->3)
                new FlightRouteStep { FlightRouteId = 27, CurrentLegId = 27, NextLegId = null, IsInitialLeg = true },//ROUTE 27(3->6)
                new FlightRouteStep { FlightRouteId = 28, CurrentLegId = 28, NextLegId = null, IsInitialLeg = true },//ROUTE 28(6->3)

                new FlightRouteStep { FlightRouteId = 29, CurrentLegId = 27, NextLegId = 41, IsInitialLeg = true },//ROUTE 29(3->7)
                new FlightRouteStep { FlightRouteId = 29, CurrentLegId = 41, NextLegId = null, IsInitialLeg = false },//ROUTE 29(3->7)

                new FlightRouteStep { FlightRouteId = 30, CurrentLegId = 42, NextLegId = 28, IsInitialLeg = true },//ROUTE 30(7->3)
                new FlightRouteStep { FlightRouteId = 30, CurrentLegId = 28, NextLegId = null, IsInitialLeg = false },//ROUTE 30(7->3)

                new FlightRouteStep { FlightRouteId = 31, CurrentLegId = 31, NextLegId = null, IsInitialLeg = true },//ROUTE 31(4->5)
                new FlightRouteStep { FlightRouteId = 32, CurrentLegId = 32, NextLegId = null, IsInitialLeg = true },//ROUTE 32(5->4)

                new FlightRouteStep { FlightRouteId = 33, CurrentLegId = 31, NextLegId = 37, IsInitialLeg = true },//ROUTE 33(4->6)
                new FlightRouteStep { FlightRouteId = 33, CurrentLegId = 37, NextLegId = null, IsInitialLeg = false },//ROUTE 33(4->6)

                new FlightRouteStep { FlightRouteId = 34, CurrentLegId = 38, NextLegId = 32, IsInitialLeg = true },//ROUTE 34(6->4)
                new FlightRouteStep { FlightRouteId = 34, CurrentLegId = 32, NextLegId = null, IsInitialLeg = false },//ROUTE 34(6->4)

                new FlightRouteStep { FlightRouteId = 35, CurrentLegId = 31, NextLegId = 37, IsInitialLeg = true },//ROUTE 35(4->7)
                new FlightRouteStep { FlightRouteId = 35, CurrentLegId = 37, NextLegId = 41, IsInitialLeg = false },//ROUTE 35(4->7)
                new FlightRouteStep { FlightRouteId = 35, CurrentLegId = 41, NextLegId = null, IsInitialLeg = false },//ROUTE 35(4->7)

                new FlightRouteStep { FlightRouteId = 36, CurrentLegId = 42, NextLegId = 38, IsInitialLeg = true },//ROUTE 36(7->4)
                new FlightRouteStep { FlightRouteId = 36, CurrentLegId = 38, NextLegId = 32, IsInitialLeg = false },//ROUTE 36(7->4)
                new FlightRouteStep { FlightRouteId = 36, CurrentLegId = 32, NextLegId = null, IsInitialLeg = false },//ROUTE 36(7->4)

                new FlightRouteStep { FlightRouteId = 37, CurrentLegId = 37, NextLegId = null, IsInitialLeg = true },//ROUTE 37(5->6)
                new FlightRouteStep { FlightRouteId = 38, CurrentLegId = 38, NextLegId = null, IsInitialLeg = true },//ROUTE 38(6->5)

                new FlightRouteStep { FlightRouteId = 39, CurrentLegId = 37, NextLegId = 41, IsInitialLeg = true },//ROUTE 39(5->7)
                new FlightRouteStep { FlightRouteId = 39, CurrentLegId = 41, NextLegId = null, IsInitialLeg = false },//ROUTE 39(5->7)

                new FlightRouteStep { FlightRouteId = 40, CurrentLegId = 42, NextLegId = 38, IsInitialLeg = true },//ROUTE 40(7->5)
                new FlightRouteStep { FlightRouteId = 40, CurrentLegId = 38, NextLegId = null, IsInitialLeg = false },//ROUTE 40(7->5)

                new FlightRouteStep { FlightRouteId = 41, CurrentLegId = 41, NextLegId = null, IsInitialLeg = true },//ROUTE 41(6->7)

                new FlightRouteStep { FlightRouteId = 42, CurrentLegId = 42, NextLegId = null, IsInitialLeg = true }//ROUTE 42(7->6)
            );

        }
    }
}
