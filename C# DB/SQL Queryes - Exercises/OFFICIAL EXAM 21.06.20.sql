CREATE DATABASE TripService

USE TripService

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode NCHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(18,2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	ArrivalDate DATETIME2 NOT NULL,
	BookDate DATETIME2 NOT NULL,
	ReturnDate DATETIME2 NOT NULL,
	CancelDate DATETIME2,
	CONSTRAINT CHK_ArrivalDate CHECK (ArrivalDate < ReturnDate),
	CONSTRAINT CHK_BookDate CHECK (BookDate < ArrivalDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATETIME2 NOT NULL,
	Email NVARCHAR(100) NOT NULL
)

CREATE TABLE AccountsTrips
(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT NOT NULL CHECK(Luggage >= 0),
	PRIMARY KEY(AccountId, TripId)
)

INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES
		('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
		('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
		('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
		('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
		(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
		(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
		(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
		(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
		(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

SELECT * FROM Rooms

UPDATE Rooms
SET Price += Price * 0.14
WHERE HotelId IN (5, 7, 9)

SELECT * FROM Trips

--04
DELETE FROM AccountsTrips
WHERE AccountId = 47

--05
SELECT FirstName,
	   LastName,
	   FORMAT(BirthDate, 'MM-dd-yyyy') AS BirthDate,
	   c.Name AS Hometown,
	   Email
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
WHERE LEFT(Email, 1) = 'e'
ORDER BY c.Name

--06
SELECT c.Name AS City,
	   COUNT(*) AS Hotels
FROM Cities AS c
JOIN Hotels AS h ON c.Id = h.CityId
GROUP BY c.Id, c.Name
ORDER BY Hotels DESC, City

--07 -------------------------------------------------
SELECT *
FROM
(	SELECT a.Id AS AccountId,
	   CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
	   MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
	FROM Trips AS t
	LEFT JOIN AccountsTrips AS actr ON t.Id = actr.TripId
	LEFT JOIN Accounts AS a ON actr.AccountId = a.Id
	WHERE a.MiddleName IS NULL AND a.ID IS NOT NULL AND t.CancelDate IS NULL
	GROUP BY a.Id, CONCAT(a.FirstName, ' ', a.LastName)
) AS SubQuery
ORDER BY LongestTrip DESC, ShortestTrip

--08
SELECT TOP(10) c.Id,
			   c.Name,
			   c.CountryCode,
			   COUNT(*) AS Accounts
FROM Cities AS c
JOIN Accounts AS a ON c.Id = a.CityId
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC

--09
SELECT a.Id,
	   a.Email,
	   c.Name,
	   COUNT(*) AS Trips
FROM Accounts AS a
LEFT JOIN Cities AS c ON a.CityId = c.Id
LEFT JOIN AccountsTrips AS actr ON a.Id = actr.AccountId
LEFT JOIN Trips AS t ON actr.TripId = t.ID
LEFT JOIN Rooms AS r ON t.RoomId = r.Id
LEFT JOIN Hotels AS h ON r.HotelId = h.ID
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC, a.ID

--10
SELECT t.Id,
	   CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName) AS [Full Name],
	   c.Name AS [From],
	   hc.Name AS [To],
	   CASE
			WHEN CancelDate IS NOT NULL THEN 'Canceled'
			ELSE CONCAT(DATEDIFF(DAY, ArrivalDate, ReturnDate),' ', 'days')
			END AS Duration
FROM Trips AS t 
JOIN AccountsTrips AS actr ON t.Id = actr.TripId
JOIN Accounts AS a ON actr.AccountId = a.Id
JOIN Cities AS c ON a.CityId = c.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS hc ON h.CityId = hc.Id
ORDER BY [Full Name], t.Id

GO

--11
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME2, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	--•	(HotelBaseRate + RoomPrice) * PeopleCount   -   TOTAL PRICE OF THE ROOM
END

GO

CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN 
	DECLARE @currRoomBeds INT = (
									SELECT Beds
									FROM Rooms
									WHERE Id = @TargetRoomId
								)

	DECLARE @tripHotel NVARCHAR(MAX) = (
											SELECT h.Name
											FROM Trips AS t
											JOIN Rooms AS r ON t.RoomId = r.Id
											JOIN Hotels AS h ON r.HotelId = h.Id
											WHERE t.Id = @TripId
									   )

	DECLARE @targetHotel NVARCHAR(MAX) = (
											SELECT h.Name
											FROM Rooms AS r
											JOIN Hotels AS h ON r.HotelId = h.Id
											WHERE r.Id = @TargetRoomId
										 )

	IF(@tripHotel != @targetHotel)
	BEGIN
		THROW 50000, 'Target room is in another hotel!', 1;
	END

	DECLARE @countOfBeds INT = (SELECT Beds
							    FROM Rooms AS r
								JOIN Trips AS t ON t.RoomId = r.Id 
								WHERE t.Id = @TripId);



	IF(@countOfBeds = 0)
	BEGIN
		THROW 50001, 'Not enough beds in target room!', 1;
	END

	DECLARE @targetRId INT = (SELECT r.Id
							    FROM Rooms AS r
								JOIN Trips AS t ON t.RoomId = r.Id 
								WHERE t.Id = 10);

	UPDATE Rooms
	SET Beds = Beds - 1
	WHERE Id = @targetRId

	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId


END

GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 8

SELECT Beds
FROM Rooms AS r
JOIN Trips AS t ON t.RoomId = r.Id
WHERE t.Id = 10

SELECT * FROM Rooms




