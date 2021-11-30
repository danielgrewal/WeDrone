USE WeDrone
GO

CREATE VIEW vw_ShowAllOrders AS
-- View 1: Computes a join of at least three tables
-- This view gets all orders in the WeDrone system, who ordered them, their
-- current status, and their origin/destination
-- and presents it in a user readable manner.

SELECT o.OrderId AS 'Order Id', CONCAT(u.FirstName,' ', u.LastName) AS
'Ordered By',
lorigin.FullAddress AS 'Package Pick-up',
ldestination.FullAddress AS 'Package Destination', s.StatusName AS 'Current
Status',
o.OrderCreated AS 'Ordered On'
FROM Orders o
INNER JOIN Users u ON o.UserId = u.UserId
INNER JOIN OrderHistory oh ON oh.OrderId = o.OrderId
INNER JOIN Status s ON s.StatusId = oh.OrderStatus
INNER JOIN Locations lorigin ON lorigin.LocationId = o.Origin
INNER JOIN Locations ldestination ON ldestination.LocationId = o.Destination
WHERE ValidTo = '9999-12-31';
GO

CREATE VIEW vw_OrdersWithWeightOver10 AS
-- View 6: Returns all orders that are over 10 kilograms in weight.

SELECT o.*
From Orders o
WHERE o.Weight < 10;
GO

CREATE VIEW vw_OrdersWithVolumeOver10 AS
-- View 7: Returns all orders that are over 10 cubic feet in volume.
SELECT o.*
From Orders o
WHERE o.Volume > 10;
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
SELECT fl.*
From FlightLegs fl
WHERE fl.Distance < 10;
GO

CREATE VIEW vw_OrdersDelivered AS
-- View 10: Return all orders that were successfully delivered
SELECT s.*
From Status s
WHERE s.Name = 'Delivered';
GO

CREATE PROCEDURE sp_GetFlightPlan
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

