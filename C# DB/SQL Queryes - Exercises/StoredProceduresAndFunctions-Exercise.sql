USE SoftUni

GO

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName FROM Employees
	WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000


GO

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18,4))
AS
BEGIN
	SELECT FirstName, LastName FROM Employees
	WHERE Salary >= @Number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100


GO

CREATE PROCEDURE usp_GetTownsStartingWith (@ParamString NVARCHAR(50))
AS
BEGIN
	SELECT Name AS [Town] FROM Towns
	WHERE LEFT(Name, LEN(@ParamString)) = @ParamString
END

EXEC usp_GetTownsStartingWith 'bell'


GO

CREATE PROCEDURE usp_GetEmployeesFromTown (@Town NVARCHAR(50))
AS
BEGIN
	SELECT e.FirstName, e.LastName FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.Name = @Town
END

EXEC usp_GetEmployeesFromTown 'Sofia'


GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7);

	IF (@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low';
	END
	ELSE IF (@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @salaryLevel = 'Average';
	END
	ELSE 
	BEGIN
		SET @salaryLevel = 'High';
	END

	RETURN @salaryLevel;
END

GO

SELECT FirstName,
	   LastName,
	   dbo.ufn_GetSalaryLevel(Salary) AS [SalaryLevel]
FROM Employees


GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel (@levelOfSalary VARCHAR(7))
AS
BEGIN
	SELECT FirstName,
		   LastName
	FROM 
		(
		 SELECT FirstName,
		 	    LastName,
		 	    dbo.ufn_GetSalaryLevel(Salary) AS [SalaryLevel]
		 FROM Employees
		) AS [SubQuery]
	WHERE SalaryLevel = @levelOfSalary
END

EXEC usp_EmployeesBySalaryLevel 'High'


GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN 
	DECLARE @currIndex INT = 1;
	WHILE (@currIndex <= LEN(@word))
	BEGIN
		DECLARE @currChar CHAR(1) = SUBSTRING(@word, @currIndex, 1);

		IF (CHARINDEX(@currChar, @setOfLetters) = 0)
		BEGIN
			RETURN 0;
		END

		SET @currIndex += 1;
	END

	RETURN 1;
END

GO

SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'halves')


GO

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN 
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
						 SELECT EmployeeID FROM Employees
						 WHERE DepartmentID = @departmentId
						)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
						 SELECT EmployeeID FROM Employees
						 WHERE DepartmentID = @departmentId
						)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
						 SELECT EmployeeID FROM Employees
						 WHERE DepartmentID = @departmentId
						)

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 1

GO

USE Bank

SELECT * FROM AccountHolders

SELECT * FROM Accounts

GO

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN 
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] FROM AccountHolders
END

EXEC usp_GetHoldersFullName

GO

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@minBalance DECIMAL(18,4))
AS
BEGIN
	SELECT *
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	GROUP BY FirstName, LastName
	HAVING SUM(a.Balance) > @minBalance
	ORDER BY FirstName, LastName
END

GO

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @futureValue DECIMAL(18,4);

	SET @futureValue = @sum * (POWER(1 + @yearlyInterestRate, @numberOfYears));

	RETURN @futureValue;
END

GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

GO

CREATE PROCEDURE usp_CalculateFutureValueForAccount (@accountID INT, @interestRate FLOAT)
AS
BEGIN
	SELECT TOP(1) *,
				  dbo.ufn_CalculateFutureValue([Current Balance], @interestRate, 5) AS [Balance in 5 years]
	FROM
		 (
		   SELECT ah.Id AS [Account Id],
				  ah.FirstName AS [First Name], 
				  ah.LastName AS [Last Name], 
				  Balance AS [Current Balance]
		   FROM Accounts AS a
		   JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
		   WHERE ah.Id = @accountID
		 ) AS [FutureValueQuery]
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

GO

USE Diablo

GO

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
RETURN SELECT (
				SELECT SUM(Cash) AS [SumCash]
				FROM (
						SELECT g.Name,
					           ug.Cash,
							   ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.Cash DESC) AS [RowNumber]
						FROM Games AS g
						JOIN UsersGames AS ug ON g.Id = ug.GameId
						WHERE g.Name = @gameName
					 ) AS [RowNumQuery]
				WHERE RowNumber % 2 <> 0
			  ) AS [SumCash]

go

SELECT * FROM dbo.ufn_CashInUsersGames ('Love in a mist')




