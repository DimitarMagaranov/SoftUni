CREATE DATABASE Minions

CREATE TABLE Minions(
Id INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
Age TINYINT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

INSERT INTO Towns(Id, [Name])
VALUES 
		(1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES 
		(1, 'Kevin', 22 , 1),
		(2, 'Bob', 15 , 3),
		(3, 'Steward', NULL , 2)

TRUNCATE TABLE Minions

SELECT * FROM Minions

DROP TABLE Minions

DROP TABLE Towns


CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(5,2),
[Weight] DECIMAL(5,2),
Gender CHAR(1) NOT NULL CHECK (Gender = 'm' OR Gender = 'f'),
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People([Name],Picture,Height,[Weight],Gender,Birthdate,Biography)
VALUES
		('Stela',NULL,1.65,44.55,'f','2000-09-22',NULL),
		('Ivan',NULL,2.15,95.55,'m','1989-11-02',NULL),
		('Qvor',NULL,1.55,33.00,'m','2010-04-11',NULL),
		('Karolina',NULL,2.15,55.55,'f','2001-11-11',NULL),
		('Pesho',NULL,1.85,90.00,'m','1983-07-22',NULL)


CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
LastLoginTime DATETIME2 NOT NULL,
IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
		('Mitko', '1234', '09.22.2015', 0),
		('Gosho', '12345', '09.22.2000', 0),
		('Pesho', '123456', '09.22.1995', 0),
		('Stoqn', '1234567', '09.22.2019', 0),
		('Ioana', '12345678', '09.22.2020', 0)

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07AD5ADB09]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength CHECK(LEN([Password]) >= 4)

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
DROP CONSTRAINT [PK_Users_CompositeIdUsername]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength CHECK(LEN(Username) >= 3)


CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
CopyrightYear VARCHAR(4),
[Length] TIME,
GenreId INT FOREIGN KEY REFERENCES Genres(id) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(id) NOT NULL,
Rating TINYINT,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName)
VALUES
		('Pesho'),
		('Gosho'),
		('Ivan'),
		('Nikolai'),
		('Stefan')

INSERT INTO Genres(GenreName)
VALUES
		('Action'),
		('Comedy'),
		('Horor'),
		('Drama'),
		('Romantic')

INSERT INTO Categories(CategoryName)
VALUES
		('First'),
		('Second'),
		('Third'),
		('Fourth'),
		('Fifth')

INSERT INTO Movies(Title, DirectorId, GenreId, CategoryId)
VALUES
		('Her Smell', 1, 1, 1),
		('The Dead Don’t Die', 2, 2, 2),
		('Fast Color', 3, 3, 3),
		('Skin', 4, 4, 4),
		('It Chapter Two', 5, 5, 5)


CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
DailyRate DECIMAL,
WeeklyRate DECIMAL,
MonthlyRate DECIMAL,
WeekendRate DECIMAL
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY,
PlateNumber NVARCHAR(10) UNIQUE NOT NULL,
Manufacturer NVARCHAR(50) NOT NULL,
Model NVARCHAR(50) NOT NULL,
CarYear VARCHAR(4) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors TINYINT CHECK(Doors = 3 OR Doors = 5) NOT NULL,
Picture VARBINARY(MAX),
Condition NVARCHAR(50),
Available BIT NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber NVARCHAR(50) NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(50) NOT NULL,
City NVARCHAR(50) NOT NULL,
ZipCode NVARCHAR(20),
Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
CarId INT FOREIGN KEY REFERENCES Cars(Id),
TankLevel DECIMAL NOT NULL,
KilometrageStart VARCHAR(10) NOT NULL,
KilometrageEnd VARCHAR(10) NOT NULL,
TotalKilometrage VARCHAR(10) NOT NULL,
SatrtDate DATE NOT NULL,
EndDate DATE NOT NULL,
TotalDays INT NOT NULL,
RateApplied VARCHAR(50) NOT NULL,
TaxRate DECIMAL NOT NULL,
OrderStatus BIT NOT NULL,
notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName)
VALUES
		('Category1'),
		('Category2'),
		('Category3')

INSERT INTO Cars(PlateNumber, Manufacturer, Model,CarYear, Doors, Available)
VALUES
		('Plate1', 'Manufacturer1', 'Model1', '1999', 3, 1),
		('Plate2', 'Manufacturer2', 'Model2', '1999', 5, 1),
		('Plate3', 'Manufacturer3', 'Model3', '1999', 3, 1)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES
		('FirstName1', 'LastName1', 'Title1'),
		('FirstName2', 'LastName2', 'Title2'),
		('FirstName3', 'LastName3', 'Title3')

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City)
VALUES
		('1111111', 'FullName1', 'Address1', 'City1'),
		('1111112', 'FullName2', 'Address2', 'City2'),
		('1111113', 'FullName3', 'Address3', 'City3')

INSERT INTO RentalOrders(TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, SatrtDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus)
VALUES
		(1111, 1111, 1111, 1111, '2018-05-10', '2018-05-11', 1, 'Rate1', 10, 1),
		(1111, 1111, 1111, 1111, '2018-05-10', '2018-05-11', 1, 'Rate1', 10, 1),
		(1111, 1111, 1111, 1111, '2018-05-10', '2018-05-11', 1, 'Rate1', 10, 1)


CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees
(
ID INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NTEXT
)
 
CREATE TABLE Customers
(
AccountNumber NVARCHAR(25) PRIMARY KEY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber NVARCHAR(50) NOT NULL,
EmergencyName NVARCHAR(50),
EmergencyNumber NVARCHAR(50),
Notes NTEXT
)
 
CREATE TABLE RoomStatus
(
RoomStatus NVARCHAR(10) PRIMARY KEY,
Notes NTEXT
)
 
CREATE TABLE RoomTypes
(
RoomType NVARCHAR(50) PRIMARY KEY,
Notes NTEXT
)
 
CREATE TABLE BedTypes
(
BedType NVARCHAR(50) PRIMARY KEY,
Notes NTEXT
)
 
CREATE TABLE Rooms
(
RoomNumber INT PRIMARY KEY IDENTITY,
RoomType NVARCHAR(50) NOT NULL,
BedType NVARCHAR(50) NOT NULL,
Rate INT,
RoomStatus NVARCHAR(10) NOT NULL,
Notes NTEXT
)
 
CREATE TABLE Payments
(
ID INT IDENTITY(1,1) PRIMARY KEY,
EmployeeID INT NOT NULL,
PaymentDate DATE NOT NULL,
AccountNumber NVARCHAR(25) NOT NULL,
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays INT,
AmountCharged DECIMAL NOT NULL,
TaxRate DECIMAL,
TaxAmount DECIMAL NOT NULL,
PaymentTotal DECIMAL NOT NULL,
Notes NTEXT
)
 
CREATE TABLE Occupancies
(
ID INT IDENTITY(1,1) PRIMARY KEY,
EmployeeID INT NOT NULL,
DateOccupied DATE NOT NULL,
AccountNumber NVARCHAR(25) NOT NULL,
RoomNumber INT NOT NULL,
RateApplied INT,
PhoneCharge DECIMAL,
Notes NTEXT
)
 
INSERT INTO Employees VALUES('Gosho', 'Goshev', 'rabotnik', '.')
INSERT INTO Employees VALUES('Tosho', 'Toshev', 'rabotnik', '.')
INSERT INTO Employees VALUES('Pesho', 'Peshev', 'rabotnik', '.')
 
INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber) VALUES('C', 'Nqkoi si 2', 'tam', 'tam')
INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber) VALUES('D', 'Nqkoi si 3', 'tam', 'tam')
INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber) VALUES('B', 'Nqkoi si 1', 'tam', 'tam')
 
INSERT INTO RoomStatus VALUES('0', 'zaeta')
INSERT INTO RoomStatus VALUES('1', 'svobodna')
INSERT INTO RoomStatus VALUES('2', 'ss')
 
INSERT INTO RoomTypes VALUES('A', 'A')
INSERT INTO RoomTypes VALUES('B', 'B')
INSERT INTO RoomTypes VALUES('C', 'C')
 
INSERT INTO BedTypes VALUES('A', 'A')
INSERT INTO BedTypes VALUES('B', 'B')
INSERT INTO BedTypes VALUES('C', 'C')
 
INSERT INTO Rooms VALUES('A', 'B', 0, '0', 'xx')
INSERT INTO Rooms VALUES('B', 'A', 0, '1', 'xx')
INSERT INTO Rooms VALUES('C', 'C', 0, '1', 'xx')
 
INSERT INTO Payments (EmployeeID, PaymentDate, AccountNumber, AmountCharged, TaxAmount, PaymentTotal) VALUES(1, GETDATE(), 'B', 1, 1, 1)
INSERT INTO Payments (EmployeeID, PaymentDate, AccountNumber, AmountCharged, TaxAmount, PaymentTotal) VALUES(2, GETDATE(), 'C', 1, 1, 1)
INSERT INTO Payments (EmployeeID, PaymentDate, AccountNumber, AmountCharged, TaxAmount, PaymentTotal) VALUES(3, GETDATE(), 'D', 1, 1, 1)


CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(100) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50),
LastName NVARCHAR(50) NOT NULL,
JobTitle NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
HireDate DATE NOT NULL,
Salary DECIMAL(7,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns([Name])
VALUES
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas')

INSERT INTO Departments([Name])
VALUES
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02-01-2013', 3500.00),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03-02-2004', 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08-28-2016', 525.25),
		('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12-09-2007', 3000.00),
		('Peter', 'Pan', 'Pan', 'Intern', 3, '08-28-2016', 599.88)


SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC


UPDATE Employees
SET Salary += Salary * 0.1

SELECT Salary FROM Employees


CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(1000),
	Notes NVARCHAR(1000)
)

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	PhoneNumber NVARCHAR(30) NOT NULL,
	EmergencyName NVARCHAR(30) NOT NULL,
	EmergencyNumber NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(1000)
)

CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(1000)
)

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(1000)
)

CREATE TABLE BedTypes (
	BedType NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(1000)
)

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(30),
	BedType NVARCHAR(30),
	Rate DECIMAL(15, 3) NOT NULL,
	RoomStatus NVARCHAR(30),
	Notes NVARCHAR(1000)
)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT,
	AmountCharged DECIMAL(15, 3) NOT NULL,
	TaxRate DECIMAL(15, 3) NOT NULL,
	TaxAmount DECIMAL(15, 3) NOT NULL,
	PaymentTotal DECIMAL(15, 3) NOT NULL,
	Notes NVARCHAR(1000)
)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL(15, 3),
	PhoneCharge DECIMAL(15, 3),
	Notes NVARCHAR(1000)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES ('Gosho', 'Goshov', 'asd', 'asd'),
	   ('Gosho2', 'Goshov2', 'asd2', 'asd2'),
	   ('Gosho3', 'Goshov3', 'asd3', 'asd3')

INSERT INTO Customers 
	(FirstName,
	LastName, PhoneNumber, 
	EmergencyName, EmergencyNumber, Notes)
VALUES ('Gosho', 'Goshov', '1234', 'Pesho1', '1234', NULL),
	   ('Gosho2', 'Goshov2', '12345', 'Pesho2', '12345', NULL),
	   ('Gosho3', 'Goshov3', '123456', 'Pesho3', '123456', NULL)

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES ('rented out', 'note'),
	   ('rented out', 'note'),
	   ('rented out', 'note')

INSERT INTO RoomTypes (RoomType, Notes)
VALUES ('Mezonet', 'note'),
	   ('Mezonet', 'note'),
	   ('Mezonet', 'note')

INSERT INTO BedTypes (BedType, Notes)
VALUES ('Meko', 'note'),
	   ('Meko', 'note'),
	   ('Meko', 'note')

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus, Notes)
VALUES ('Mezonet', 'Meko', 3.1, 'rented out', NULL),
	   ('Mezonet', 'Meko', 3.1, 'rented out', NULL),
	   ('Mezonet', 'Meko', 3.1, 'rented out', NULL)

INSERT INTO Payments 
		(EmployeeId, PaymentDate,
		AccountNumber, FirstDateOccupied, LastDateOccupied,
		TotalDays, AmountCharged, TaxRate, 
		TaxAmount, PaymentTotal, Notes)
VALUES (1, '02-02-2002', 3, '02-02-2002', '02-03-2002', 1, 2, 2, 2, 2, NULL),
	   (1, '02-02-2002', 3, '02-02-2002', '02-03-2002', 1, 2, 2, 2, 2, NULL),
	   (1, '02-02-2002', 3, '02-02-2002', '02-03-2002', 1, 2, 2, 2, 2, NULL)

INSERT INTO Occupancies 
		(EmployeeId, DateOccupied, AccountNumber,
		RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES (1, '02-02-2002', 1, 1, 2, 123, NULL),
	   (1, '02-02-2002', 1, 1, 2, 123, NULL),
	   (1, '02-02-2002', 1, 1, 2, 123, NULL)

UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments


TRUNCATE TABLE Occupancies

SELECT * FROM Occupancies
