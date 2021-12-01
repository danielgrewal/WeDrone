using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeDrone.Web.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(17,14)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(17,14)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDroneFacility = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Flightlegs",
                columns: table => new
                {
                    FlightlegId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromId = table.Column<int>(type: "int", nullable: false),
                    ToId = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flightlegs", x => x.FlightlegId);
                    table.ForeignKey(
                        name: "FK_Flightlegs_Locations_FromId",
                        column: x => x.FromId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flightlegs_Locations_ToId",
                        column: x => x.ToId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightRoutes",
                columns: table => new
                {
                    FlightRouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteStartId = table.Column<int>(type: "int", nullable: false),
                    RouteEndId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightRoutes", x => x.FlightRouteId);
                    table.ForeignKey(
                        name: "FK_FlightRoutes_Locations_RouteEndId",
                        column: x => x.RouteEndId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightRoutes_Locations_RouteStartId",
                        column: x => x.RouteStartId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightRouteSteps",
                columns: table => new
                {
                    FlightRouteId = table.Column<int>(type: "int", nullable: false),
                    CurrentLegId = table.Column<int>(type: "int", nullable: false),
                    NextLegId = table.Column<int>(type: "int", nullable: true),
                    IsInitialLeg = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightRouteSteps", x => new { x.FlightRouteId, x.CurrentLegId });
                    table.ForeignKey(
                        name: "FK_FlightRouteSteps_Flightlegs_CurrentLegId",
                        column: x => x.CurrentLegId,
                        principalTable: "Flightlegs",
                        principalColumn: "FlightlegId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightRouteSteps_Flightlegs_NextLegId",
                        column: x => x.NextLegId,
                        principalTable: "Flightlegs",
                        principalColumn: "FlightlegId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    FlightRouteId = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    OrderCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderFilled = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_FlightRoutes_FlightRouteId",
                        column: x => x.FlightRouteId,
                        principalTable: "FlightRoutes",
                        principalColumn: "FlightRouteId");
                    table.ForeignKey(
                        name: "FK_Orders_Locations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Locations_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistory",
                columns: table => new
                {
                    Orderid = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromId = table.Column<int>(type: "int", nullable: true),
                    ToId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistory", x => new { x.Orderid, x.ValidFrom });
                    table.ForeignKey(
                        name: "FK_OrderHistory_Locations_FromId",
                        column: x => x.FromId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderHistory_Locations_ToId",
                        column: x => x.ToId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderHistory_Orders_Orderid",
                        column: x => x.Orderid,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderHistory_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "IsDroneFacility", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, "6301 Silver Dart Dr, Mississauga, ON L5P 1B2", true, 43.68232877980147m, -79.62661047567958m, "Toronto Pearson International Airport" },
                    { 2, "100 City Centre Dr, Mississauga, ON L5B 2C9", true, 43.5932704575367m, -79.6418354765629m, "Square One Shopping Centre" },
                    { 3, "1 Bass Pro Mills Dr, Vaughan, ON L4K 5W4", true, 43.82549302652521m, -79.5381447146669m, "Vaughan Mills Mall" },
                    { 4, "290 Bremner Blvd, Toronto, ON M5V 3L9", true, 43.64272145936629m, -79.38704607234244m, "CN Tower" },
                    { 5, "770 Don Mills Rd., North York, ON M3C 1T3", true, 43.71718851953277m, -79.33851344772478m, "Ontario Science Centre" },
                    { 6, "2000 Meadowvale Rd, Toronto, ON M1B 5K7", true, 43.82096417612802m, -79.1812287514316m, "Toronto Zoo" },
                    { 7, "2000 Simcoe St N, Oshawa, ON L1G 0C5", true, 43.94565647325994m, -78.89679613001036m, "Ontario Technology University" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Pending Pick-up" },
                    { 2, "Order Retrieved" },
                    { 3, "In Transit" },
                    { 4, "Pending Drop-off" },
                    { 5, "Delivered" },
                    { 6, "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "Usman Mahmood", "password", "usman" },
                    { 2, "Daniel Grewal", "password", "daniel" },
                    { 3, "Mohammed Adnan Hashmi", "password", "adnan" },
                    { 4, "Karanvir Bhogal", "password", "karanvir" }
                });

            migrationBuilder.InsertData(
                table: "FlightRoutes",
                columns: new[] { "FlightRouteId", "RouteEndId", "RouteStartId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 1, 2 },
                    { 3, 3, 1 },
                    { 4, 1, 3 },
                    { 5, 4, 1 },
                    { 6, 1, 4 },
                    { 7, 5, 1 },
                    { 8, 1, 5 },
                    { 9, 6, 1 },
                    { 10, 1, 6 },
                    { 11, 7, 1 },
                    { 12, 1, 7 },
                    { 13, 3, 2 },
                    { 14, 2, 3 },
                    { 15, 4, 2 },
                    { 16, 2, 4 },
                    { 17, 5, 2 },
                    { 18, 2, 5 },
                    { 19, 6, 2 },
                    { 20, 2, 6 },
                    { 21, 7, 2 },
                    { 22, 2, 7 },
                    { 23, 4, 3 },
                    { 24, 3, 4 },
                    { 25, 5, 3 },
                    { 26, 3, 5 },
                    { 27, 6, 3 },
                    { 28, 3, 6 },
                    { 29, 7, 3 },
                    { 30, 3, 7 },
                    { 31, 5, 4 },
                    { 32, 4, 5 },
                    { 33, 6, 4 },
                    { 34, 4, 6 },
                    { 35, 7, 4 },
                    { 36, 4, 7 },
                    { 37, 6, 5 },
                    { 38, 5, 6 },
                    { 39, 7, 5 },
                    { 40, 5, 7 },
                    { 41, 7, 6 },
                    { 42, 6, 7 }
                });

            migrationBuilder.InsertData(
                table: "Flightlegs",
                columns: new[] { "FlightlegId", "Distance", "FromId", "ToId" },
                values: new object[,]
                {
                    { 1, 9.98m, 1, 2 },
                    { 2, 9.98m, 2, 1 },
                    { 3, 17.43m, 1, 3 },
                    { 4, 17.43m, 3, 1 },
                    { 5, 19.77m, 1, 4 },
                    { 6, 19.77m, 4, 1 },
                    { 7, 23.48m, 1, 5 },
                    { 8, 23.48m, 5, 1 },
                    { 9, 38.95m, 1, 6 },
                    { 10, 38.95m, 6, 1 },
                    { 11, 65.47m, 1, 7 },
                    { 12, 65.47m, 7, 1 },
                    { 13, 27.13m, 2, 3 },
                    { 14, 27.13m, 3, 2 },
                    { 15, 21.24m, 2, 4 },
                    { 16, 21.24m, 4, 2 },
                    { 17, 28.02m, 2, 5 },
                    { 18, 28.02m, 5, 2 },
                    { 19, 44.85m, 2, 6 },
                    { 20, 44.85m, 6, 2 },
                    { 21, 71.51m, 2, 7 },
                    { 22, 71.51m, 7, 2 },
                    { 23, 23.67m, 3, 4 },
                    { 24, 23.67m, 4, 3 },
                    { 25, 20.05m, 3, 5 },
                    { 26, 20.05m, 5, 3 },
                    { 27, 28.64m, 3, 6 },
                    { 28, 28.64m, 6, 3 },
                    { 29, 53.11m, 3, 7 },
                    { 30, 53.11m, 7, 3 },
                    { 31, 9.15m, 4, 5 },
                    { 32, 9.15m, 5, 4 },
                    { 33, 25.81m, 4, 6 },
                    { 34, 25.81m, 6, 4 },
                    { 35, 51.8m, 4, 7 },
                    { 36, 51.8m, 7, 4 },
                    { 37, 17.11m, 5, 6 },
                    { 38, 17.11m, 6, 5 },
                    { 39, 43.6m, 5, 7 },
                    { 40, 43.6m, 7, 5 },
                    { 41, 26.68m, 6, 7 },
                    { 42, 26.68m, 7, 6 }
                });

            migrationBuilder.InsertData(
                table: "FlightRouteSteps",
                columns: new[] { "CurrentLegId", "FlightRouteId", "IsInitialLeg", "NextLegId" },
                values: new object[,]
                {
                    { 1, 1, true, null },
                    { 2, 2, true, null },
                    { 3, 3, true, null },
                    { 4, 4, true, null },
                    { 5, 5, true, null },
                    { 6, 6, true, null },
                    { 7, 7, true, null },
                    { 8, 8, true, null },
                    { 7, 9, true, 37 },
                    { 37, 9, false, null },
                    { 8, 10, false, null },
                    { 38, 10, true, 8 },
                    { 7, 11, true, 37 },
                    { 37, 11, false, 41 },
                    { 41, 11, false, null },
                    { 8, 12, false, null },
                    { 38, 12, false, 8 },
                    { 42, 12, true, 38 },
                    { 2, 13, true, 3 },
                    { 3, 13, false, null },
                    { 1, 14, false, null },
                    { 4, 14, true, 1 },
                    { 15, 15, true, null },
                    { 16, 16, true, null },
                    { 15, 17, true, 31 },
                    { 31, 17, false, null },
                    { 16, 18, false, null },
                    { 32, 18, true, 16 },
                    { 15, 19, true, 31 },
                    { 31, 19, false, 37 },
                    { 37, 19, false, null },
                    { 16, 20, false, null },
                    { 32, 20, false, 16 },
                    { 38, 20, true, 32 },
                    { 15, 21, true, 31 },
                    { 31, 21, false, 37 },
                    { 37, 21, false, 41 },
                    { 41, 21, false, null },
                    { 16, 22, false, null },
                    { 32, 22, false, 16 },
                    { 38, 22, false, 32 },
                    { 42, 22, true, 38 }
                });

            migrationBuilder.InsertData(
                table: "FlightRouteSteps",
                columns: new[] { "CurrentLegId", "FlightRouteId", "IsInitialLeg", "NextLegId" },
                values: new object[,]
                {
                    { 7, 23, true, null },
                    { 8, 24, true, null },
                    { 25, 25, true, null },
                    { 26, 26, true, null },
                    { 27, 27, true, null },
                    { 28, 28, true, null },
                    { 27, 29, true, 41 },
                    { 41, 29, false, null },
                    { 28, 30, false, null },
                    { 42, 30, true, 28 },
                    { 31, 31, true, null },
                    { 32, 32, true, null },
                    { 31, 33, true, 37 },
                    { 37, 33, false, null },
                    { 32, 34, false, null },
                    { 38, 34, true, 32 },
                    { 31, 35, true, 37 },
                    { 37, 35, false, 41 },
                    { 41, 35, false, null },
                    { 32, 36, false, null },
                    { 38, 36, false, 32 },
                    { 42, 36, true, 38 },
                    { 37, 37, true, null },
                    { 38, 38, true, null },
                    { 37, 39, true, 41 },
                    { 41, 39, false, null },
                    { 38, 40, false, null },
                    { 42, 40, true, 38 },
                    { 41, 41, true, null },
                    { 42, 42, true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flightlegs_FromId",
                table: "Flightlegs",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Flightlegs_ToId",
                table: "Flightlegs",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightRoutes_RouteEndId",
                table: "FlightRoutes",
                column: "RouteEndId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightRoutes_RouteStartId",
                table: "FlightRoutes",
                column: "RouteStartId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightRouteSteps_CurrentLegId",
                table: "FlightRouteSteps",
                column: "CurrentLegId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightRouteSteps_NextLegId",
                table: "FlightRouteSteps",
                column: "NextLegId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Address",
                table: "Locations",
                column: "Address",
                unique: true,
                filter: "[Address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_FromId",
                table: "OrderHistory",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_StatusId",
                table: "OrderHistory",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_ToId",
                table: "OrderHistory",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DestinationId",
                table: "Orders",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FlightRouteId",
                table: "Orders",
                column: "FlightRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OriginId",
                table: "Orders",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightRouteSteps");

            migrationBuilder.DropTable(
                name: "OrderHistory");

            migrationBuilder.DropTable(
                name: "Flightlegs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "FlightRoutes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
