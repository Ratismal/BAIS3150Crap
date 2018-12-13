CREATE DATABASE KMorrill2;

USE KMorrill2;

-- DROP
DROP TABLE SaleItem;
DROP TABLE Sale;
DROP TABLE Customer;
DROP TABLE Item;

-- DEFINE
CREATE TABLE Customer (
  CustomerID INT IDENTITY(1,1),
  CustomerName VARCHAR(60) NOT NULL,
  Address VARCHAR(100) NOT NULL,
  City VARCHAR(50) NOT NULL,
  Province VARCHAR(30) NOT NULL,
  PostalCode VARCHAR(7) NOT NULL,
  Deleted BIT NOT NULL DEFAULT 0
);

ALTER TABLE Customer
  ADD CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID),
      CONSTRAINT CK_PostalCode CHECK (PostalCode LIKE '[A-Z][0-9][A-Z] [0-9][A-Z][0-9]'),
      CONSTRAINT CK_CustomerID CHECK (CustomerID >= 1);

CREATE TABLE Item (
  ItemCode VARCHAR(6) NOT NULL,
  Description VARCHAR(100) NOT NULL,
  UnitPrice MONEY NOT NULL,
  QuantityOnHand INT NOT NULL DEFAULT 0,
  Deleted BIT NOT NULL DEFAULT 0
);

ALTER TABLE Item
  ADD CONSTRAINT PK_ItemCode PRIMARY KEY (ItemCode),
      CONSTRAINT CK_UnitPrice CHECK (UnitPrice >= 0);

CREATE TABLE Sale (
  SaleNumber INT IDENTITY(1,1),
  SaleDate DATETIME NOT NULL,
  SalesPerson VARCHAR(60) NOT NULL,
  CustomerID INT NOT NULL,
  SubTotal MONEY DEFAULT 0.00,
  GST MONEY DEFAULT 0.00,
  SaleTotal MONEY DEFAULT 0.00
);

ALTER TABLE Sale
  ADD CONSTRAINT PK_SaleNumber PRIMARY KEY (SaleNumber),
      CONSTRAINT FK_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
      CONSTRAINT CK_SaleNumber CHECK (SaleNumber >= 1);

CREATE TABLE SaleItem (
  SaleNumber INT NOT NULL,
  ItemCode VARCHAR(6) NOT NULL,
  Quantity INT DEFAULT 0,
  ItemTotal MONEY DEFAULT 0.00
);

ALTER TABLE SaleItem
  ADD CONSTRAINT PK_SaleItem PRIMARY KEY (SaleNumber, ItemCode),
      CONSTRAINT FK_SaleNumber FOREIGN KEY (SaleNumber) REFERENCES Sale(SaleNumber),
      CONSTRAINT FK_ItemCode FOREIGN KEY (ItemCode) REFERENCES Item(ItemCode);

-- POPULATE
INSERT INTO Item (ItemCode, Description, UnitPrice, QuantityOnHand) VALUES ('I12847', 'Vice Grib 1/2 Inch', 10.00, 100);
INSERT INTO Item (ItemCode, Description, UnitPrice, QuantityOnHand) VALUES ('N22475', 'Claw Hammer', 15.00, 150);
INSERT INTO Item (ItemCode, Description, UnitPrice, QuantityOnHand) VALUES ('P77455', 'Torque Wrench', 75.00, 200);

SET IDENTITY_INSERT Customer ON;
INSERT INTO Customer (CustomerID, CustomerName, Address, City, Province, PostalCode) VALUES (
  123123123, 'John Smith', '12345 67 Street', 'Edmonton', 'Alberta', 'T6T 6T6'
);
SET IDENTITY_INSERT Customer OFF;

SET IDENTITY_INSERT Sale ON;
INSERT INTO Sale (SaleNumber, SaleDate, SalesPerson, CustomerID, SubTotal, GST, SaleTotal) VALUES (
  123456789, '01/16/2004', 'Jenny Brooks', 123123123, 115.00, 8.05, 123.05
);
SET IDENTITY_INSERT Sale OFF;

INSERT INTO SaleItem (SaleNumber, ItemCode, Quantity, ItemTotal) VALUES (123456789, 'I12847', 1, 10.00);
INSERT INTO SaleItem (SaleNumber, ItemCode, Quantity, ItemTotal) VALUES (123456789, 'N22475', 2, 30.00);
INSERT INTO SaleItem (SaleNumber, ItemCode, Quantity, ItemTotal) VALUES (123456789, 'P77455', 1, 75.00);

-- PROCEDURES

DROP PROCEDURE RetrieveSale;
CREATE PROCEDURE RetrieveSale(@SaleNumber INT) AS
  DECLARE @ReturnCode INT
  SET @ReturnCode = 1
  SELECT
    Sale.SaleNumber, SaleDate, SalesPerson, 
    Customer.CustomerName, Customer.Address, Customer.City,
    Customer.Province, Customer.PostalCode, Item.ItemCode,
    Description, UnitPrice, Quantity, 
    ItemTotal, SubTotal, GST, SaleTotal
  FROM SALE
    INNER JOIN Customer ON Sale.CustomerID = Customer.CustomerID
    INNER JOIN SaleItem ON Sale.SaleNumber = SaleItem.SaleNumber
    INNER JOIN Item ON Item.ItemCode = SaleItem.ItemCode
  WHERE Sale.SaleNumber = @SaleNumber;

  IF @@ERROR = 0
    SET @ReturnCode = 0
  ELSE RAISERROR('RetrieveSale - SELECT error.', 16, 1)

  RETURN @ReturnCode

EXEC RetrieveSale 123456789;

DROP PROCEDURE AddItem;
CREATE PROCEDURE AddItem(@ItemCode VARCHAR(6), @Description VARCHAR(100), @UnitPrice MONEY) AS
  DECLARE @ReturnCode INT
  SET @ReturnCode = 1

  INSERT INTO Item (ItemCode, Description, UnitPrice) VALUES (@ItemCode, @Description, @UnitPrice);

  IF @@ERROR = 0
    SET @ReturnCode = 0
  ELSE RAISERROR('AddItem - INSERT error - Item table.', 16, 1)

  RETURN @ReturnCode

DROP PROCEDURE UpdateItem;
CREATE PROCEDURE UpdateItem(@ItemCode VARCHAR(6), @Description VARCHAR(100), @UnitPrice MONEY) AS
  DECLARE @ReturnCode INT
  SET @ReturnCode = 1

  UPDATE Item SET Description = @Description, UnitPrice = @UnitPrice WHERE ItemCode = @ItemCode;

  IF @@ERROR = 0
    SET @ReturnCode = 0
  ELSE RAISERROR('AddItem - UPDATE error - Item table.', 16, 1)

  RETURN @ReturnCode

DROP PROCEDURE DeleteItem;
CREATE PROCEDURE DeleteItem(@ItemCode VARCHAR(6)) AS
  DECLARE @ReturnCode INT
  SET @ReturnCode = 1

  DELETE FROM Item WHERE ItemCode = @ItemCode;

  IF @@ERROR = 0
    SET @ReturnCode = 0
  ELSE RAISERROR('AddItem - DELETE error - Item table.', 16, 1)

  RETURN @ReturnCode

EXEC AddItem 'N11111', 'A thing', 1.00;
SELECT * FROM Item;
EXEC UpdateItem 'N11111', 'A thing!', 2.00;
SELECT * FROM Item;
EXEC DeleteItem 'N11111';
SELECT * FROM Item;

DROP PROCEDURE AddCustomer;
CREATE PROCEDURE AddCustomer(
  @CustomerName VARCHAR(60), @Address VARCHAR(100), @City VARCHAR(50),
  @Province VARCHAR(30), @PostalCode VARCHAR(7) 
) AS
  DECLARE @ReturnCode INT
  SET @ReturnCode = 1

  INSERT INTO Customer (CustomerName, Address, City, Province, PostalCode) VALUES (
    @CustomerName, @Address, @City, @Province, @PostalCode
  );

  IF @@ERROR = 0
    SET @ReturnCode = 0
  ELSE RAISERROR('AddItem - INSERT error - Customer table.', 16, 1)

  RETURN @ReturnCode

DROP PROCEDURE UpdateCustomer;
CREATE PROCEDURE UpdateCustomer(
  @CustomerID INT, @CustomerName VARCHAR(60), @Address VARCHAR(100), 
  @City VARCHAR(50), @Province VARCHAR(30), @PostalCode VARCHAR(7) 
) AS
  DECLARE @ReturnCode INT
  SET @ReturnCode = 1

  UPDATE Customer SET
    CustomerName = @CustomerName,
    Address = @Address,
    City = @City,
    Province = @Province,
    PostalCode = @PostalCode
    WHERE CustomerID = @CustomerID;

  IF @@ERROR = 0
    SET @ReturnCode = 0
  ELSE RAISERROR('AddItem - UPDATE error - Customer table.', 16, 1)

  RETURN @ReturnCode

DROP PROCEDURE DeleteCustomer;
CREATE PROCEDURE DeleteCustomer(@CustomerID INT) AS
  DECLARE @ReturnCode INT
  SET @ReturnCode = 1

  DELETE FROM Customer WHERE CustomerID = @CustomerID;

  IF @@ERROR = 0
    SET @ReturnCode = 0
  ELSE RAISERROR('AddItem - DELETE error - Customer table.', 16, 1)

  RETURN @ReturnCode

select * from item;

select * from item;

CREATE USER aspnet FOR LOGIN [NAIT\WEBBAIST$];
GRANT SELECT, INSERT, DELETE, UPDATE ON Item TO aspnet;
GRANT SELECT, INSERT, DELETE, UPDATE ON SaleItem TO aspnet;
GRANT SELECT, INSERT, DELETE, UPDATE ON Sale TO aspnet;
GRANT SELECT, INSERT, DELETE, UPDATE ON Customer TO aspnet;