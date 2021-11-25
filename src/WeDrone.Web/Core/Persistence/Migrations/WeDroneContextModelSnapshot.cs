﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeDrone.Web.Core.Persistence;

#nullable disable

namespace WeDrone.Web.Core.Persistence.Migrations
{
    [DbContext(typeof(WeDroneContext))]
    partial class WeDroneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WeDrone.Web.Core.Domain.Flightleg", b =>
                {
                    b.Property<int>("FlightlegId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightlegId"), 1L, 1);

                    b.Property<decimal>("Distance")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("FromId")
                        .HasColumnType("int");

                    b.Property<int>("Toid")
                        .HasColumnType("int");

                    b.HasKey("FlightlegId");

                    b.HasIndex("FromId");

                    b.HasIndex("Toid");

                    b.ToTable("Flightlegs");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.FlightRoute", b =>
                {
                    b.Property<int>("FlightRouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightRouteId"), 1L, 1);

                    b.Property<int>("RouteEndId")
                        .HasColumnType("int");

                    b.Property<int>("RouteStartId")
                        .HasColumnType("int");

                    b.HasKey("FlightRouteId");

                    b.HasIndex("RouteEndId");

                    b.HasIndex("RouteStartId");

                    b.ToTable("FlightRoutes");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.FlightRouteStep", b =>
                {
                    b.Property<int>("FlightRouteId")
                        .HasColumnType("int");

                    b.Property<int>("CurrentLegId")
                        .HasColumnType("int");

                    b.Property<bool>("IsInitialLeg")
                        .HasColumnType("bit");

                    b.Property<int?>("NextLegId")
                        .HasColumnType("int");

                    b.HasKey("FlightRouteId", "CurrentLegId");

                    b.HasIndex("CurrentLegId");

                    b.HasIndex("NextLegId");

                    b.ToTable("FlightRouteStep");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDroneFacility")
                        .HasColumnType("bit");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(17,14)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(17,14)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int>("FlightRouteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OrderFilled")
                        .HasColumnType("datetime2");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("FlightRouteId");

                    b.HasIndex("OriginId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.OrderHistory", b =>
                {
                    b.Property<int>("Orderid")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Distance")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("FromId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("datetime2");

                    b.HasKey("Orderid", "ValidFrom");

                    b.HasIndex("FromId");

                    b.HasIndex("StatusId");

                    b.HasIndex("ToId");

                    b.ToTable("OrderHistory");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.Flightleg", b =>
                {
                    b.HasOne("WeDrone.Web.Core.Domain.Location", "From")
                        .WithMany("FromFlightlegs")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WeDrone.Web.Core.Domain.Location", "To")
                        .WithMany("ToFlightlegs")
                        .HasForeignKey("Toid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.FlightRoute", b =>
                {
                    b.HasOne("WeDrone.Web.Core.Domain.Location", "RouteEnd")
                        .WithMany("EndFlightRoutes")
                        .HasForeignKey("RouteEndId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WeDrone.Web.Core.Domain.Location", "RouteStart")
                        .WithMany("StartFlightRoutes")
                        .HasForeignKey("RouteStartId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RouteEnd");

                    b.Navigation("RouteStart");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.FlightRouteStep", b =>
                {
                    b.HasOne("WeDrone.Web.Core.Domain.Flightleg", "CurrentLeg")
                        .WithMany("CurrentLegSteps")
                        .HasForeignKey("CurrentLegId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WeDrone.Web.Core.Domain.Flightleg", "NextLeg")
                        .WithMany("NextlegSteps")
                        .HasForeignKey("NextLegId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CurrentLeg");

                    b.Navigation("NextLeg");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.Order", b =>
                {
                    b.HasOne("WeDrone.Web.Core.Domain.Location", "Destination")
                        .WithMany("DestinationOrders")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WeDrone.Web.Core.Domain.FlightRoute", "FlightRoute")
                        .WithMany("Orders")
                        .HasForeignKey("FlightRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeDrone.Web.Core.Domain.Location", "Origin")
                        .WithMany("OriginOrders")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WeDrone.Web.Core.Domain.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("FlightRoute");

                    b.Navigation("Origin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.OrderHistory", b =>
                {
                    b.HasOne("WeDrone.Web.Core.Domain.Location", "From")
                        .WithMany("FromHistory")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WeDrone.Web.Core.Domain.Order", "Order")
                        .WithMany("HistoryEntries")
                        .HasForeignKey("Orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeDrone.Web.Core.Domain.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeDrone.Web.Core.Domain.Location", "To")
                        .WithMany("ToHistory")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("Order");

                    b.Navigation("Status");

                    b.Navigation("To");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.Flightleg", b =>
                {
                    b.Navigation("CurrentLegSteps");

                    b.Navigation("NextlegSteps");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.FlightRoute", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.Location", b =>
                {
                    b.Navigation("DestinationOrders");

                    b.Navigation("EndFlightRoutes");

                    b.Navigation("FromFlightlegs");

                    b.Navigation("FromHistory");

                    b.Navigation("OriginOrders");

                    b.Navigation("StartFlightRoutes");

                    b.Navigation("ToFlightlegs");

                    b.Navigation("ToHistory");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.Order", b =>
                {
                    b.Navigation("HistoryEntries");
                });

            modelBuilder.Entity("WeDrone.Web.Core.Domain.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
