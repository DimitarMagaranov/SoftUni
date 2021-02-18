CREATE DATABASE Airport

USE Airport

CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME2,
	ArrivalTime DATETIME2,
	Origin NVARCHAR(50) NOT NULL,
	Destination NVARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	PassportId NCHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Type] NVARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(18,2) NOT NULL
)

INSERT INTO Planes([Name], Seats, [Range])
VALUES
		('Airbus 336', 112, 5132),
		('Airbus 330', 432, 5325),
		('Boeing 369', 231, 2355),
		('Stelt 297', 254, 2143),
		('Boeing 338', 165, 5111),
		('Airbus 558', 387, 1342),
		('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes([Type])
VALUES
		('Crossbody Bag'),
		('School Backpack'),
		('Shoulder Bag')


UPDATE Tickets
SET Price = Price + Price * 0.13
WHERE FlightId IN (
					SELECT Id FROM Flights
					WHERE Destination = 'Carlsbad'
				  )

DELETE FROM Tickets
WHERE FlightId IN (
					SELECT Id FROM Flights
					WHERE Destination = 'Ayn Halagim'
				  )

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'


SELECT * FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]

SELECT f.Id AS FlightId,
SUM(t.Price) AS Price 
FROM Flights AS f
JOIN Tickets AS t ON f.Id = t.FlightId
GROUP BY f.Id
ORDER BY Price DESC

SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
	   f.Origin,
	   f.Destination
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
ORDER BY [Full Name], f.Origin, f.Destination

SELECT FirstName,
	   LastName,
	   Age
FROM Passengers AS p
LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY Age DESC, FirstName, LastName


SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
	   pl.Name AS [Plane Name],
	   CONCAT(f.Origin, ' - ', f.Destination) AS [Trip],
	   lt.Type AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
JOIN Planes AS pl ON f.PlaneId = pl.Id
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]

SELECT *
FROM
	(
		SELECT p.Name AS [Name],
			   p.Seats AS [Seats],
			   COUNT(t.PassengerId) AS [Passengers Count]
		FROM Planes AS p
		LEFT JOIN Flights AS f ON p.Id = f.PlaneId
		LEFT JOIN Tickets AS t ON f.Id = t.FlightId
		GROUP BY p.Id, p.Name, p.Seats
	 ) AS [GroupingQuery]
ORDER BY [Passengers Count] DESC, [Name], [Seats]

GO

CREATE FUNCTION udf_CalculateTickets (@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT) 
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @messageForInvalidPeopleCount NVARCHAR(MAX) = 'Invalid people count!';
	DECLARE @messageForInvalidFlight NVARCHAR(MAX) = 'Invalid flight!';

	IF(@peopleCount <= 0)
	BEGIN
		RETURN @messageForInvalidPeopleCount;
	END

	IF(@origin NOT IN (SELECT Origin FROM Flights) OR @destination NOT IN (SELECT Destination FROM Flights))
	BEGIN
		RETURN @messageForInvalidFlight;
	END

	DECLARE @totalPrice DECIMAL(18,2) = (SELECT TOP(1) t.Price FROM Flights AS f
										JOIN Tickets AS t ON f.Id = t.FlightId
										WHERE f.Origin = @origin AND f.Destination = @destination) * @peopleCount;

	RETURN CONCAT('Total price', ' ', CAST(@totalPrice AS NVARCHAR(MAX)))
END

GO

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

GO

CREATE PROCEDURE usp_CancelFlights
AS
BEGIN
	UPDATE Flights
	SET DepartureTime = NULL, ArrivalTime = NULL
	WHERE ArrivalTime > DepartureTime
END

GO

EXEC usp_CancelFlights