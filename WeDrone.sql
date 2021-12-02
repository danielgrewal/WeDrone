CREATE DATABASE WeDrone;
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Locations] (
    [LocationId] int NOT NULL IDENTITY,
    [Name] nvarchar(255) NULL,
    [Latitude] decimal(17,14) NOT NULL,
    [Longitude] decimal(17,14) NOT NULL,
    [Address] nvarchar(255) NULL,
    [IsDroneFacility] bit NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY ([LocationId])
);
GO

CREATE TABLE [Status] (
    [StatusId] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY ([StatusId])
);
GO

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Username] nvarchar(50) NOT NULL,
    [Password] nvarchar(50) NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Flightlegs] (
    [FlightlegId] int NOT NULL IDENTITY,
    [FromId] int NOT NULL,
    [ToId] int NOT NULL,
    [Distance] decimal(10,2) NOT NULL,
    CONSTRAINT [PK_Flightlegs] PRIMARY KEY ([FlightlegId]),
    CONSTRAINT [FK_Flightlegs_Locations_FromId] FOREIGN KEY ([FromId]) REFERENCES [Locations] ([LocationId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Flightlegs_Locations_ToId] FOREIGN KEY ([ToId]) REFERENCES [Locations] ([LocationId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [FlightRoutes] (
    [FlightRouteId] int NOT NULL IDENTITY,
    [RouteStartId] int NOT NULL,
    [RouteEndId] int NOT NULL,
    CONSTRAINT [PK_FlightRoutes] PRIMARY KEY ([FlightRouteId]),
    CONSTRAINT [FK_FlightRoutes_Locations_RouteEndId] FOREIGN KEY ([RouteEndId]) REFERENCES [Locations] ([LocationId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_FlightRoutes_Locations_RouteStartId] FOREIGN KEY ([RouteStartId]) REFERENCES [Locations] ([LocationId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [FlightRouteSteps] (
    [FlightRouteId] int NOT NULL,
    [CurrentLegId] int NOT NULL,
    [NextLegId] int NULL,
    [IsInitialLeg] bit NOT NULL,
    CONSTRAINT [PK_FlightRouteSteps] PRIMARY KEY ([FlightRouteId], [CurrentLegId]),
    CONSTRAINT [FK_FlightRouteSteps_Flightlegs_CurrentLegId] FOREIGN KEY ([CurrentLegId]) REFERENCES [Flightlegs] ([FlightlegId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_FlightRouteSteps_Flightlegs_NextLegId] FOREIGN KEY ([NextLegId]) REFERENCES [Flightlegs] ([FlightlegId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Orders] (
    [OrderId] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [OriginId] int NOT NULL,
    [DestinationId] int NOT NULL,
    [FlightRouteId] int NULL,
    [Weight] decimal(10,2) NOT NULL,
    [Volume] decimal(10,2) NOT NULL,
    [Cost] decimal(10,2) NOT NULL,
    [OrderCreated] datetime2 NULL,
    [OrderFilled] datetime2 NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
    CONSTRAINT [FK_Orders_FlightRoutes_FlightRouteId] FOREIGN KEY ([FlightRouteId]) REFERENCES [FlightRoutes] ([FlightRouteId]),
    CONSTRAINT [FK_Orders_Locations_DestinationId] FOREIGN KEY ([DestinationId]) REFERENCES [Locations] ([LocationId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Orders_Locations_OriginId] FOREIGN KEY ([OriginId]) REFERENCES [Locations] ([LocationId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderHistory] (
    [Orderid] int NOT NULL,
    [ValidFrom] datetime2 NOT NULL,
    [ValidTo] datetime2 NOT NULL,
    [FromId] int NULL,
    [ToId] int NULL,
    [StatusId] int NOT NULL,
    [Distance] decimal(10,2) NULL,
    CONSTRAINT [PK_OrderHistory] PRIMARY KEY ([Orderid], [ValidFrom]),
    CONSTRAINT [FK_OrderHistory_Locations_FromId] FOREIGN KEY ([FromId]) REFERENCES [Locations] ([LocationId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrderHistory_Locations_ToId] FOREIGN KEY ([ToId]) REFERENCES [Locations] ([LocationId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrderHistory_Orders_Orderid] FOREIGN KEY ([Orderid]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderHistory_Status_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Status] ([StatusId]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'LocationId', N'Address', N'IsDroneFacility', N'Latitude', N'Longitude', N'Name') AND [object_id] = OBJECT_ID(N'[Locations]'))
    SET IDENTITY_INSERT [Locations] ON;
INSERT INTO [Locations] ([LocationId], [Address], [IsDroneFacility], [Latitude], [Longitude], [Name])
VALUES (1, N'6301 Silver Dart Dr, Mississauga, ON L5P 1B2', CAST(1 AS bit), 43.68232877980147, -79.62661047567958, N'Toronto Pearson International Airport'),
(2, N'100 City Centre Dr, Mississauga, ON L5B 2C9', CAST(1 AS bit), 43.5932704575367, -79.6418354765629, N'Square One Shopping Centre'),
(3, N'1 Bass Pro Mills Dr, Vaughan, ON L4K 5W4', CAST(1 AS bit), 43.82549302652521, -79.5381447146669, N'Vaughan Mills Mall'),
(4, N'290 Bremner Blvd, Toronto, ON M5V 3L9', CAST(1 AS bit), 43.64272145936629, -79.38704607234244, N'CN Tower'),
(5, N'770 Don Mills Rd., North York, ON M3C 1T3', CAST(1 AS bit), 43.71718851953277, -79.33851344772478, N'Ontario Science Centre'),
(6, N'2000 Meadowvale Rd, Toronto, ON M1B 5K7', CAST(1 AS bit), 43.82096417612802, -79.1812287514316, N'Toronto Zoo'),
(7, N'2000 Simcoe St N, Oshawa, ON L1G 0C5', CAST(1 AS bit), 43.94565647325994, -78.89679613001036, N'Ontario Technology University');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'LocationId', N'Address', N'IsDroneFacility', N'Latitude', N'Longitude', N'Name') AND [object_id] = OBJECT_ID(N'[Locations]'))
    SET IDENTITY_INSERT [Locations] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StatusId', N'Name') AND [object_id] = OBJECT_ID(N'[Status]'))
    SET IDENTITY_INSERT [Status] ON;
INSERT INTO [Status] ([StatusId], [Name])
VALUES (1, N'Pending Pick-up'),
(2, N'Order Retrieved'),
(3, N'In Transit'),
(4, N'Pending Drop-off'),
(5, N'Delivered'),
(6, N'Cancelled');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'StatusId', N'Name') AND [object_id] = OBJECT_ID(N'[Status]'))
    SET IDENTITY_INSERT [Status] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'Name', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([UserId], [Name], [Password], [Username])
VALUES (1, N'Usman Mahmood', N'password', N'usman'),
(2, N'Daniel Grewal', N'password', N'daniel'),
(3, N'Mohammed Adnan Hashmi', N'password', N'adnan'),
(4, N'Karanvir Bhogal', N'password', N'karanvir');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'Name', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'FlightRouteId', N'RouteEndId', N'RouteStartId') AND [object_id] = OBJECT_ID(N'[FlightRoutes]'))
    SET IDENTITY_INSERT [FlightRoutes] ON;
INSERT INTO [FlightRoutes] ([FlightRouteId], [RouteEndId], [RouteStartId])
VALUES (1, 2, 1),
(2, 1, 2),
(3, 3, 1),
(4, 1, 3),
(5, 4, 1),
(6, 1, 4),
(7, 5, 1),
(8, 1, 5),
(9, 6, 1),
(10, 1, 6),
(11, 7, 1),
(12, 1, 7),
(13, 3, 2),
(14, 2, 3),
(15, 4, 2),
(16, 2, 4),
(17, 5, 2),
(18, 2, 5),
(19, 6, 2),
(20, 2, 6),
(21, 7, 2),
(22, 2, 7),
(23, 4, 3),
(24, 3, 4),
(25, 5, 3),
(26, 3, 5),
(27, 6, 3),
(28, 3, 6),
(29, 7, 3),
(30, 3, 7),
(31, 5, 4),
(32, 4, 5),
(33, 6, 4),
(34, 4, 6),
(35, 7, 4),
(36, 4, 7),
(37, 6, 5),
(38, 5, 6),
(39, 7, 5),
(40, 5, 7),
(41, 7, 6),
(42, 6, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'FlightRouteId', N'RouteEndId', N'RouteStartId') AND [object_id] = OBJECT_ID(N'[FlightRoutes]'))
    SET IDENTITY_INSERT [FlightRoutes] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'FlightlegId', N'Distance', N'FromId', N'ToId') AND [object_id] = OBJECT_ID(N'[Flightlegs]'))
    SET IDENTITY_INSERT [Flightlegs] ON;
INSERT INTO [Flightlegs] ([FlightlegId], [Distance], [FromId], [ToId])
VALUES (1, 9.98, 1, 2),
(2, 9.98, 2, 1),
(3, 17.43, 1, 3),
(4, 17.43, 3, 1),
(5, 19.77, 1, 4),
(6, 19.77, 4, 1),
(7, 23.48, 1, 5),
(8, 23.48, 5, 1),
(9, 38.95, 1, 6),
(10, 38.95, 6, 1),
(11, 65.47, 1, 7),
(12, 65.47, 7, 1),
(13, 27.13, 2, 3),
(14, 27.13, 3, 2),
(15, 21.24, 2, 4),
(16, 21.24, 4, 2),
(17, 28.02, 2, 5),
(18, 28.02, 5, 2),
(19, 44.85, 2, 6),
(20, 44.85, 6, 2),
(21, 71.51, 2, 7),
(22, 71.51, 7, 2),
(23, 23.67, 3, 4),
(24, 23.67, 4, 3),
(25, 20.05, 3, 5),
(26, 20.05, 5, 3),
(27, 28.64, 3, 6),
(28, 28.64, 6, 3),
(29, 53.11, 3, 7),
(30, 53.11, 7, 3),
(31, 9.15, 4, 5),
(32, 9.15, 5, 4),
(33, 25.81, 4, 6),
(34, 25.81, 6, 4),
(35, 51.8, 4, 7),
(36, 51.8, 7, 4),
(37, 17.11, 5, 6),
(38, 17.11, 6, 5),
(39, 43.6, 5, 7),
(40, 43.6, 7, 5),
(41, 26.68, 6, 7),
(42, 26.68, 7, 6);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'FlightlegId', N'Distance', N'FromId', N'ToId') AND [object_id] = OBJECT_ID(N'[Flightlegs]'))
    SET IDENTITY_INSERT [Flightlegs] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CurrentLegId', N'FlightRouteId', N'IsInitialLeg', N'NextLegId') AND [object_id] = OBJECT_ID(N'[FlightRouteSteps]'))
    SET IDENTITY_INSERT [FlightRouteSteps] ON;
INSERT INTO [FlightRouteSteps] ([CurrentLegId], [FlightRouteId], [IsInitialLeg], [NextLegId])
VALUES (1, 1, CAST(1 AS bit), NULL),
(2, 2, CAST(1 AS bit), NULL),
(3, 3, CAST(1 AS bit), NULL),
(4, 4, CAST(1 AS bit), NULL),
(5, 5, CAST(1 AS bit), NULL),
(6, 6, CAST(1 AS bit), NULL),
(7, 7, CAST(1 AS bit), NULL),
(8, 8, CAST(1 AS bit), NULL),
(7, 9, CAST(1 AS bit), 37),
(37, 9, CAST(0 AS bit), NULL),
(8, 10, CAST(0 AS bit), NULL),
(38, 10, CAST(1 AS bit), 8),
(7, 11, CAST(1 AS bit), 37),
(37, 11, CAST(0 AS bit), 41),
(41, 11, CAST(0 AS bit), NULL),
(8, 12, CAST(0 AS bit), NULL),
(38, 12, CAST(0 AS bit), 8),
(42, 12, CAST(1 AS bit), 38),
(2, 13, CAST(1 AS bit), 3),
(3, 13, CAST(0 AS bit), NULL),
(1, 14, CAST(0 AS bit), NULL),
(4, 14, CAST(1 AS bit), 1),
(15, 15, CAST(1 AS bit), NULL),
(16, 16, CAST(1 AS bit), NULL),
(15, 17, CAST(1 AS bit), 31),
(31, 17, CAST(0 AS bit), NULL),
(16, 18, CAST(0 AS bit), NULL),
(32, 18, CAST(1 AS bit), 16),
(15, 19, CAST(1 AS bit), 31),
(31, 19, CAST(0 AS bit), 37),
(37, 19, CAST(0 AS bit), NULL),
(16, 20, CAST(0 AS bit), NULL),
(32, 20, CAST(0 AS bit), 16),
(38, 20, CAST(1 AS bit), 32),
(15, 21, CAST(1 AS bit), 31),
(31, 21, CAST(0 AS bit), 37),
(37, 21, CAST(0 AS bit), 41),
(41, 21, CAST(0 AS bit), NULL),
(16, 22, CAST(0 AS bit), NULL),
(32, 22, CAST(0 AS bit), 16),
(38, 22, CAST(0 AS bit), 32),
(42, 22, CAST(1 AS bit), 38);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CurrentLegId', N'FlightRouteId', N'IsInitialLeg', N'NextLegId') AND [object_id] = OBJECT_ID(N'[FlightRouteSteps]'))
    SET IDENTITY_INSERT [FlightRouteSteps] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CurrentLegId', N'FlightRouteId', N'IsInitialLeg', N'NextLegId') AND [object_id] = OBJECT_ID(N'[FlightRouteSteps]'))
    SET IDENTITY_INSERT [FlightRouteSteps] ON;
INSERT INTO [FlightRouteSteps] ([CurrentLegId], [FlightRouteId], [IsInitialLeg], [NextLegId])
VALUES (7, 23, CAST(1 AS bit), NULL),
(8, 24, CAST(1 AS bit), NULL),
(25, 25, CAST(1 AS bit), NULL),
(26, 26, CAST(1 AS bit), NULL),
(27, 27, CAST(1 AS bit), NULL),
(28, 28, CAST(1 AS bit), NULL),
(27, 29, CAST(1 AS bit), 41),
(41, 29, CAST(0 AS bit), NULL),
(28, 30, CAST(0 AS bit), NULL),
(42, 30, CAST(1 AS bit), 28),
(31, 31, CAST(1 AS bit), NULL),
(32, 32, CAST(1 AS bit), NULL),
(31, 33, CAST(1 AS bit), 37),
(37, 33, CAST(0 AS bit), NULL),
(32, 34, CAST(0 AS bit), NULL),
(38, 34, CAST(1 AS bit), 32),
(31, 35, CAST(1 AS bit), 37),
(37, 35, CAST(0 AS bit), 41),
(41, 35, CAST(0 AS bit), NULL),
(32, 36, CAST(0 AS bit), NULL),
(38, 36, CAST(0 AS bit), 32),
(42, 36, CAST(1 AS bit), 38),
(37, 37, CAST(1 AS bit), NULL),
(38, 38, CAST(1 AS bit), NULL),
(37, 39, CAST(1 AS bit), 41),
(41, 39, CAST(0 AS bit), NULL),
(38, 40, CAST(0 AS bit), NULL),
(42, 40, CAST(1 AS bit), 38),
(41, 41, CAST(1 AS bit), NULL),
(42, 42, CAST(1 AS bit), NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CurrentLegId', N'FlightRouteId', N'IsInitialLeg', N'NextLegId') AND [object_id] = OBJECT_ID(N'[FlightRouteSteps]'))
    SET IDENTITY_INSERT [FlightRouteSteps] OFF;
GO

CREATE INDEX [IX_Flightlegs_FromId] ON [Flightlegs] ([FromId]);
GO

CREATE INDEX [IX_Flightlegs_ToId] ON [Flightlegs] ([ToId]);
GO

CREATE INDEX [IX_FlightRoutes_RouteEndId] ON [FlightRoutes] ([RouteEndId]);
GO

CREATE INDEX [IX_FlightRoutes_RouteStartId] ON [FlightRoutes] ([RouteStartId]);
GO

CREATE INDEX [IX_FlightRouteSteps_CurrentLegId] ON [FlightRouteSteps] ([CurrentLegId]);
GO

CREATE INDEX [IX_FlightRouteSteps_NextLegId] ON [FlightRouteSteps] ([NextLegId]);
GO

CREATE UNIQUE INDEX [IX_Locations_Address] ON [Locations] ([Address]) WHERE [Address] IS NOT NULL;
GO

CREATE INDEX [IX_OrderHistory_FromId] ON [OrderHistory] ([FromId]);
GO

CREATE INDEX [IX_OrderHistory_StatusId] ON [OrderHistory] ([StatusId]);
GO

CREATE INDEX [IX_OrderHistory_ToId] ON [OrderHistory] ([ToId]);
GO

CREATE INDEX [IX_Orders_DestinationId] ON [Orders] ([DestinationId]);
GO

CREATE INDEX [IX_Orders_FlightRouteId] ON [Orders] ([FlightRouteId]);
GO

CREATE INDEX [IX_Orders_OriginId] ON [Orders] ([OriginId]);
GO

CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
GO

CREATE UNIQUE INDEX [IX_Users_Username] ON [Users] ([Username]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211202045809_initial', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

USE WeDrone
GO

CREATE VIEW vw_ShowAllOrders AS
-- View 1: Computes a join of at least three tables
-- This view gets all orders in the WeDrone system, who ordered them, their
-- current status, and their origin/destination
-- and presents it in a user readable manner.

SELECT o.OrderId AS 'Order Id', u.Name AS
'Ordered By',
lorigin.Address AS 'Package Pick-up',
ldestination.Address AS 'Package Destination', s.Name AS 'Current Status',
oh.ValidFrom AS 'Last Update',
o.OrderCreated AS 'Ordered On'

FROM Orders o
INNER JOIN Users u ON o.UserId = u.UserId
INNER JOIN OrderHistory oh ON oh.OrderId = o.OrderId
INNER JOIN Status s ON s.StatusId = oh.StatusId
INNER JOIN Locations lorigin ON lorigin.LocationId = o.OriginId
INNER JOIN Locations ldestination ON ldestination.LocationId = o.DestinationId
WHERE oh.ValidFrom < GETDATE() AND oh.ValidTo > GETDATE()
GO

CREATE VIEW vw_OrdersWithDistanceNotCancelled AS

-- View 2: Uses nested queries with the ANY or ALL operator and uses a GROUP BY clause
-- Returns all orders that were not cancelled and also provides the aggregate sum of the distance travelled in each order.

SELECT o.*, od.Distance
FROM Orders o
INNER JOIN (
	SELECT OrderId, SUM(distance) AS 'Distance'
	FROM OrderHistory oh
	GROUP BY OrderId) AS od ON od.OrderId = o.OrderId
WHERE NOT (o.OrderId = ANY(SELECT DISTINCT OrderId FROM OrderHistory WHERE OrderHistory.StatusId = 6));
GO

CREATE VIEW vw_CustomersWithFilledOrders AS
-- View 3: A correlated nested query
-- Returns user records for all users that have created orders that have been delivered.

SELECT * FROM Users u
WHERE EXISTS (
	SELECT UserId FROM Orders o 
	WHERE o.UserId = u.UserId AND o.OrderFilled IS NOT NULL
);
GO

CREATE VIEW vw_AllUsersAndTheirOrders AS
-- View 4: Uses a FULL JOIN
-- Returns all users and all of their associated orders, if they have made any.

SELECT u.*, o.OrderId, o.OriginId, o.DestinationId, o.Weight, o.Volume, o.OrderCreated, o.OrderFilled 
FROM Users u
FULL JOIN Orders o ON o.UserId = u.UserId;
GO

CREATE VIEW vw_OrdersWithWeightOver10 AS
-- View 6: Returns all orders that are over 10 kilograms in weight.

SELECT OrderId
From Orders o
WHERE o.Weight > 10;
GO

CREATE VIEW vw_OrdersWithVolumeOver1 AS
-- View 7: Returns all orders that are over 1 cubic feet in volume.
SELECT OrderId
From Orders o
WHERE o.Volume > 1;
GO

CREATE VIEW vw_ShowFacilityNodes AS
-- View 8: Returns all location nodes that are marked as "facility nodes".
-- These are the nodes that are fixed and represent where drones are stored
-- The opposite is when DroneFacility = 0, these are pickup/drop off locations
-- Later in the application when more nodes are added, we want to easily be able
-- to find these locations from the stored user locations.
SELECT l.*
From Locations l
WHERE l.IsDroneFacility = 1;
GO

CREATE VIEW vw_FlightLegsLessThan10 AS
-- View 9: Returns all flight legs that are less than 10 km
-- These are the shortest distance routes between nodes
SELECT fl.*, l.Address 'FromAddress', l2.Address 'ToAddress'
From FlightLegs fl
INNER JOIN Locations l on l.LocationId = fl.FromId
INNER JOIN Locations l2 on l2.LocationId = fl.ToId
WHERE fl.Distance < 10;
GO

CREATE VIEW vw_OrdersDelivered AS
-- View 10: Return all orders that were successfully delivered
SELECT Count (*) 'OrdersDelivered'
From Status s
INNER JOIN OrderHistory oh on oh.StatusId = s.StatusId
WHERE s.Name = 'Delivered'
AND oh.ValidFrom < GETDATE() AND oh.ValidTo > GETDATE();
GO

CREATE PROCEDURE sp_GetFlightPlan
-- View 5: This view was converted to a stored procedure to allow the recursive CTE
-- to be passed in initial values to build from

	@RouteStartId		INT,
	@RouteEndId			INT
AS
BEGIN
	
	WITH FlightPlanCTE (FlightRouteId, RouteStartId, RouteEndId, CurrentLegId, NextLegId)
	AS
	(
		-- Initial leg
		SELECT fr.FlightRouteId, fr.RouteStartId, fr.RouteEndId, s.CurrentLegId, s.NextLegId 
		FROM FlightRouteSteps s
		INNER JOIN FlightRoutes fr ON fr.FlightRouteId = s.FlightRouteId
		WHERE fr.RouteStartId = @RouteStartId AND fr.RouteEndId = @RouteEndId AND s.IsInitialLeg = 1

		UNION ALL

		-- Recursive call to next leg
		SELECT fr.FlightRouteId, fr.RouteStartId, fr.RouteEndId, s.CurrentLegId, s.NextLegId 
		FROM FlightRouteSteps s
		INNER JOIN FlightRoutes fr ON fr.FlightRouteId = s.FlightRouteId
		INNER JOIN FlightPlanCTE ON s.CurrentLegId = FlightPlanCTE.NextLegId
		WHERE fr.RouteStartId = @RouteStartId AND fr.RouteEndId = @RouteEndId
	)

	SELECT fl.*
	FROM FlightPlanCTE fp
	INNER JOIN FlightLegs fl ON fp.CurrentLegId = fl.FlightLegId;

END


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211202045833_runSQL', N'6.0.0');
GO

COMMIT;
GO

