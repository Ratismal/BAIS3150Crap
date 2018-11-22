DROP PROCEDURE KMorrill2ForXmlRaw;
DROP PROCEDURE KMorrill2ForXmlAuto;
DROP PROCEDURE KMorrill2ForXmlElements;
DROP PROCEDURE KMorrill2ForXmlPath;

CREATE PROCEDURE KMorrill2ForXmlRaw AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, ISNULL(Region,'N/A') AS Region, PostalCode, Country, Phone, Fax FROM Customers FOR XML RAW;

	IF @@ERROR = 0
		SET @ReturnCode = 1
	ELSE
		RAISERROR('KMorrill2ForXmlRaw - SELECT error: Customers table.',16,1)

	RETURN @ReturnCode

CREATE PROCEDURE KMorrill2ForXmlAuto @Country VARCHAR(15) AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, ISNULL(Region,'N/A') AS Region, PostalCode, Country, Phone, Fax FROM Customers 
		WHERE Country = @Country FOR XML AUTO;

	IF @@ERROR = 0
		SET @ReturnCode = 1
	ELSE
		RAISERROR('KMorrill2ForXmlAuto - SELECT error: Customers table.',16,1)

	RETURN @ReturnCode

CREATE PROCEDURE KMorrill2ForXmlContact @ContactTitle VARCHAR(30) AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, ISNULL(Region,'N/A') AS Region, PostalCode, Country, Phone, Fax FROM Customers 
		WHERE ContactTitle = @ContactTitle FOR XML AUTO, XMLSCHEMA;

	IF @@ERROR = 0
		SET @ReturnCode = 1
	ELSE
		RAISERROR('KMorrill2ForXmlContactTitle- SELECT error: Customers table.',16,1)

	RETURN @ReturnCode

CREATE PROCEDURE KMorrill2ForXmlElements @Country VARCHAR(15), @City VARCHAR(15) AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, ISNULL(Region,'N/A') AS Region, PostalCode, Country, Phone, Fax FROM Customers 
		WHERE Country = @Country AND City = @City FOR XML AUTO, ELEMENTS XSINIL;

	IF @@ERROR = 0
		SET @ReturnCode = 1
	ELSE
		RAISERROR('KMorrill2ForXmlElements - SELECT error: Customers table.',16,1)

	RETURN @ReturnCode

CREATE PROCEDURE KMorrill2ForXmlPath @Country VARCHAR(15), @City VARCHAR(15) AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, ISNULL(Region,'N/A') AS Region, PostalCode, Country, Phone, Fax FROM Customers 
		WHERE Country = @Country AND City = @City FOR XML PATH;

	IF @@ERROR = 0
		SET @ReturnCode = 1
	ELSE
		RAISERROR('KMorrill2ForXmlPath - SELECT error: Customers table.',16,1)

	RETURN @ReturnCode

SELECT * FROM Customers;

EXECUTE KMorrill2ForXmlContact 'Sales Agent';