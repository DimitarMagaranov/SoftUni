USE SoftUni

SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

SELECT FirstName FROM Employees
WHERE DepartmentID IN (3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

SELECT [Name] FROM Towns
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

SELECT TownID, [Name] FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

SELECT TownID, [Name] FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT FirstName, LastName FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

SELECT * FROM (SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000) AS [Rank Table]
WHERE [Rank] = 2
ORDER BY Salary DESC


USE Geography

SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode

SELECT p.PeakName, r.RiverName, LOWER(CONCAT(P.PeakName, SUBSTRING(r.RiverName, 2, LEN(r.RiverName) - 1))) AS Mix FROM Peaks AS p, Rivers AS r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix

USE Diablo

SELECT TOP(50) Name, FORMAT(Start, 'yyyy-MM-dd') AS Start FROM Games
WHERE DATEPART(YEAR, Start) IN (2011, 2012)
ORDER BY Start, Name

SELECT Username,
	   SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
	  FROM Users
ORDER BY [Email Provider], Username

SELECT Username, IpAddress AS [IP Address] FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

SELECT [Name],
	CASE 
			WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
			WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
			ELSE 'Evening'
	END AS [Part of the Day],
	CASE	
			WHEN Duration <= 3 THEN 'Extra Short'
			WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
			WHEN Duration > 6 THEN 'Long'
			ELSE 'Extra Long'
	END AS [Duration]
FROM Games
ORDER BY [Name], [Duration], [Part of the Day]

CREATE DATABASE Orders

USE Orders

CREATE TABLE Orders
(
	[Id] INT PRIMARY KEY IDENTITY,
	[ProductName] VARCHAR(50) NOT NULL,
	[OrderDate] DATETIME2 NOT NULL
)

INSERT INTO Orders([ProductName], [OrderDate])
VALUES
		('Butter', '2016-09-19'),
		('Milk', '2016-09-30'),
		('Cheese', '2016-09-04'),
		('Bread', '2015-12-20'),
		('Tomatoes', '2015-12-30')

SELECT [ProductName],
	   [OrderDate],
	   DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
	   DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
FROM Orders


CREATE TABLE People
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL
)


INSERT INTO People([Name], [Birthdate])
VALUES
		('Victor', '2000-12-07'),
		('Steven', '1992-09-10 '),
		('Stephen', '1910-09-19'),
		('John', '2010-01-06')

SELECT [Name],
	   DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age In Years],
	   DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age In Months],
	   DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age In Days],
	   DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age In Minutes]
FROM People
