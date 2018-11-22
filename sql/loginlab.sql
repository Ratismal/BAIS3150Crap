USE Northwind;

CREATE PROCEDURE GetNorthwindCategories AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	SELECT CategoryID, CategoryName, Description, Picture FROM Categories ORDER BY CategoryName DESC

	RETURN @ReturnCode
