DROP PROCEDURE KMorrill2GetCustomersByCountry

CREATE PROCEDURE KMorrill2GetCustomersByCountry @Country VARCHAR(15) = NULL AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @Country IS NULL
		RAISERROR('KMorrill2GetCustomersByCountry - Missing required parameter @Country', 16, 1)
	ELSE BEGIN	
		SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Phone, Fax
			FROM Customers
			WHERE Country = @Country

		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('KMorrill2GetCustomersByCountry - SELECT error: Customers table', 16, 1)
	END

	RETURN @ReturnCode

EXECUTE KMorrill2GetCustomersByCountry 'Germany'
EXECUTE KMorrill2GetCustomersByCountry

DROP PROCEDURE KMorrill2GetCategory

CREATE PROCEDURE KMorrill2GetCategory @CategoryID INT = NULL AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @CategoryID IS NULL
		RAISERROR('KMorrill2GetCategory - Missing required parameter @CategoryID', 16, 1)
	ELSE BEGIN
		SELECT CategoryID, CategoryName, Description FROM Categories WHERE CategoryID = @CategoryID

		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('KMorrill2GetCategory - SELECT error: Categories table', 16, 1)
	END

	RETURN @ReturnCode

EXECUTE KMorrill2GetCategory 1
EXECUTE KMorrill2GetCategory

DROP PROCEDURE KMorrill2GetProductsByCategory

CREATE PROCEDURE KMorrill2GetProductsByCategory @CategoryID INT = NULL AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @CategoryID IS NULL
		RAISERROR('KMorrill2GetProductsByCategory - Missing required parameter @CategoryID', 16, 1)
	ELSE BEGIN
		SELECT ProductID, ProductName, Suppliers.CompanyName, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued 
			FROM Products INNER JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID WHERE CategoryID = @CategoryID

		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			RAISERROR('KMorrill2GetProductsByCategory - SELECT error: Products table', 16, 1)
	END

	RETURN @ReturnCode

EXECUTE KMorrill2GetProductsByCategory 1
EXECUTE KMorrill2GetProductsByCategory