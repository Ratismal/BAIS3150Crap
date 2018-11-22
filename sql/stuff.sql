CREATE DATABASE KMorrill2;

USE KMorrill2;

-- ====
-- DROP
-- ====

DROP TABLE Student;
DROP TABLE Program;

-- ============
-- DEFINE TABLE
-- ============

CREATE TABLE Program (
	ProgramCode VARCHAR(10) PRIMARY KEY,
	Description VarChar(60)
);

CREATE TABLE Student (
	StudentID VARCHAR(10) NOT NULL PRIMARY KEY,
	FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25) NOT NULL,
	Email VARCHAR(50) NULL,
	ProgramCode VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES Program(ProgramCode)
);

-- ===========
-- INSERT DATA
-- ===========

INSERT INTO Program (ProgramCode, Description) VALUES ('BAIS0000', 'General Information Course');
INSERT INTO Program (ProgramCode, Description) VALUES ('BAIS3010', 'IT Professional Development Studies');
INSERT INTO Program (ProgramCode, Description) VALUES ('BAIS3020', 'Strategic Planning and Project Management');
INSERT INTO Program (ProgramCode, Description) VALUES ('BAIS3110', 'Information Systems Architecture and Security');
INSERT INTO Program (ProgramCode, Description) VALUES ('BAIS3130', 'Software Engineering I: Product Research Concepts');
INSERT INTO Program (ProgramCode, Description) VALUES ('BAIS3150', 'Software Development Tools');
INSERT INTO Program (ProgramCode, Description) VALUES ('BAIS3170', 'Introduction to Enterprise Resource Planning');

INSERT INTO Student (StudentID, FirstName, LastName, Email, ProgramCode) VALUES ('0001', 'Jane', 'Doe', 'janedoe@nait.ca', 'BAIS3010');
INSERT INTO Student (StudentID, FirstName, LastName, Email, ProgramCode) VALUES ('0002', 'John', 'Doe', 'johndoe@nait.ca', 'BAIS3110');
INSERT INTO Student (StudentID, FirstName, LastName, Email, ProgramCode) VALUES ('0003', 'Mary', 'Sue', 'marysue@nait.ca', 'BAIS3010');
INSERT INTO Student (StudentID, FirstName, LastName, Email, ProgramCode) VALUES ('0004', 'Suzy', 'Que', 'suzyque@nait.ca', 'BAIS3170');

-- =================
-- DEFINE PROCEDURES
-- =================

-- GetPrograms
CREATE PROCEDURE GetPrograms AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	SELECT ProgramCode, Description FROM PROGRAM

	IF @@ERROR = 0
		SET @ReturnCode = 1
	ELSE
		RAISERROR('GetPrograms - SELECT error: Program table.',16,1)

	RETURN @ReturnCode

EXECUTE GetPrograms

-- CreateProgram
CREATE PROCEDURE CreateProgram @ProgramCode VARCHAR(10) = NULL, @Description VARCHAR(60) = NULL AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @ProgramCode IS NULL
		RAISERROR('CreateProgram - Missing parameter @ProgramCode',16,1);	
	ELSE IF @Description IS NULL
		RAISERROR('CreateProgram - Missing parameter @Description',16,1);
	ELSE BEGIN
		INSERT INTO Program (ProgramCode, Description) VALUES (@ProgramCode, @Description);

		IF @@ERROR = 0
			SET @ReturnCode = 1
		ELSE
			RAISERROR('CreateProgram - INSERT error: Program table.',16,1)
	END

	RETURN @ReturnCode

EXECUTE CreateProgram 'IST0000', 'Information Systems Technology Department Page';
EXECUTE CreateProgram

-- EnrollStudent
CREATE PROCEDURE EnrollStudent @StudentID VARCHAR(10), @FirstName VARCHAR(25),
		@LastName VARCHAR(25), @Email VARCHAR(50) = null, @ProgramCode VARCHAR(10) AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	INSERT INTO Student (StudentID, FirstName, LastName, Email, ProgramCode) 
		VALUES (@StudentID, @FirstName, @LastName, @Email, @ProgramCode);

	IF @@ERROR = 0
		SET @ReturnCode = 1
	ELSE
		RAISERROR('EnrollStudent - INSERT error: Student table.',16,1)


	RETURN @ReturnCode

-- EnrollStudent
CREATE PROCEDURE ModifyStudent @StudentID VARCHAR(10), @FirstName VARCHAR(25),
		@LastName VARCHAR(25), @Email VARCHAR(50) = null, @ProgramCode VARCHAR(10) AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	UPDATE Student SET FirstName = @FirstName, LastName = @LastName,
		Email = @Email, ProgramCode = @ProgramCode WHERE StudentID = @StudentID;

	IF @@ERROR = 0
		SET @ReturnCode = 1
	ELSE
		RAISERROR('ModifyStudent - UPDATE error: Student table.',16,1)


	RETURN @ReturnCode

-- FindStudent
CREATE PROCEDURE FindStudent @StudentID VARCHAR(10) = NULL AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @StudentID IS NULL
		RAISERROR('FindStudent - Missing parameter @StudentID',16,1)
	ELSE BEGIN
		SELECT StudentID, FirstName, LastName, Email, ProgramCode FROM Student WHERE StudentID = @StudentID

		IF @@ERROR = 0
			SET @ReturnCode = 1
		ELSE
			RAISERROR('FindStudent - SELECT error: Student table.',16,1)
	END

	RETURN @ReturnCode;

EXECUTE FindStudent '0001';

-- RemoveStudent
CREATE PROCEDURE RemoveStudent @StudentID VARCHAR(10) = NULL AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @StudentID IS NULL
		RAISERROR('RemoveStudent - Missing parameter @StudentID',16,1)
	ELSE BEGIN
		DELETE Student WHERE StudentID = @StudentID

		IF @@ERROR = 0
			SET @ReturnCode = 1
		ELSE
			RAISERROR('RemoveStudentStudent - DELETE error: Student table.',16,1)
	END

	RETURN @ReturnCode;

EXECUTE RemoveStudent '0001';

-- FindProgram
CREATE PROCEDURE FindProgram @ProgramCode VARCHAR(10) = NULL AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @ProgramCode IS NULL
		RAISERROR('FindProgram - Missing parameter @ProgramCode',16,1)
	ELSE BEGIN
		SELECT ProgramCode, Description FROM Program WHERE ProgramCode = @ProgramCode

		IF @@ERROR = 0
			SET @ReturnCode = 1
		ELSE
			RAISERROR('FindProgram - SELECT error: Program table.',16,1)
	END

	RETURN @ReturnCode;

EXECUTE FindProgram 'BAIS0000';