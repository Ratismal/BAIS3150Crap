
CREATE DATABASE KMorrill2BAIS3110Authentication;

USE KMorrill2BAIS3110Authentication;

CREATE TABLE Users (
  Email VARCHAR(256) PRIMARY KEY,
  Password VARCHAR(256)
);

CREATE PROCEDURE AddUser (@Email VARCHAR(256), @Password VARCHAR(256)) AS
  DECLARE @ReturnCode INT
  SET @ReturnCode = 1

  INSERT INTO Users (Email, Password) VALUES (@Email, @Password);
  IF @@ERROR = 0
    SET @ReturnCode = 0
  ELSE RAISERROR('AddUser: INSERT error: Users table',16,1)

  RETURN @ReturnCode

CREATE PROCEDURE GetUser (@Email VARCHAR(256)) AS
  DECLARE @ReturnCode INT
  SET @ReturnCode = 1

  SELECT Email, Password FROM Users WHERE Email = @Email;
  IF @@ERROR = 0
    SET @ReturnCode = 0
  ELSE RAISERROR('GetUser: SELECT error: Users table',16,1)

  RETURN @ReturnCode