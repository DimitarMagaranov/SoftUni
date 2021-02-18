CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(255) NOT NULL,
	IssueStatus NCHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	[Message] NVARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Size DECIMAL(18,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)


INSERT INTO Files([Name], Size, ParentId, CommitId)
VALUES
		('Trade.idk', 2598.0, 1, 1),
		('menu.net', 9238.31, 2, 2),
		('Administrate.soshy', 1246.93, 3, 3),
		('Controller.php', 7353.15, 4, 4),
		('Find.java', 9957.86, 5, 5),
		('Controller.json', 14034.87, 3, 6),
		('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues([Title], IssueStatus, RepositoryId, AssigneeId)
VALUES
		('Critical Problem with HomeController.cs file', 'open', 1, 4),
		('Typo fix in Judge.html', 'open', 1, 4),
		('Implement documentation for UsersService.cs', 'closed', 8, 2),
		('Unreachable code in Index.cs', 'open', 9, 8)

UPDATE Issues
SET IssueStatus = 'closed' WHERE AssigneeId = 6

SELECT * FROM Repositories

DELETE FROM RepositoriesContributors
WHERE RepositoryId = (
						SELECT Id FROM Repositories
						WHERE Name = 'Softuni-Teamwork'
					 )

DELETE FROM Issues
WHERE RepositoryId = (
						SELECT Id FROM Repositories
						WHERE Name = 'Softuni-Teamwork'
					 )


SELECT Id,
	   Message,
	   RepositoryId,
	   ContributorId
FROM Commits
ORDER BY Id, Message, RepositoryId, ContributorId

SELECT Id,
	   Name,
	   Size
FROM Files
WHERE Size > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC, Id, Name

SELECT i.Id,
	   CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, IssueAssignee

SELECT pf.Id,
	   pf.Name,
	   CONCAT(CONVERT(VARCHAR, pf.Size), 'KB') AS [Size]
FROM Files AS pf
LEFT JOIN Files AS f ON pf.Id = f.ParentId
WHERE f.Id IS NULL
ORDER BY pf.Id, pf.Name, pf.Size

SELECT TOP(5) r.Id,
			  r.Name,
			  COUNT(c.RepositoryId) AS [Commits]
FROM Repositories AS r
JOIN Commits AS c ON r.Id = c.RepositoryId
LEFT JOIN RepositoriesContributors AS rc
ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY Commits DESC, r.Id, r.Name

SELECT * FROM Repositories AS r
JOIN Commits AS c ON r.Id = c.RepositoryId
WHERE r.Name = 'WorkWork'

SELECT *
FROM (
	  SELECT u.Username AS Username,
			 AVG(f.Size) AS Size
	  FROM Users AS u
	  LEFT JOIN Commits AS c ON u.Id = c.ContributorId
	  LEFT JOIN Files AS f ON c.Id = f.CommitId
	  GROUP BY u.Id, u.Username
	 ) AS AvgQuery
WHERE Size IS NOT NULL
ORDER BY Size DESC, Username

GO

CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @result INT = (
							SELECT COUNT(*) FROM Commits
							WHERE ContributorId = (
													SELECT Id FROM Users
													WHERE Username = @username
												  )
						  )

	RETURN @result;
END

GO

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

GO

CREATE PROCEDURE usp_FindByExtension(@extension NVARCHAR(5))
AS
BEGIN
	SELECT Id,
		   Name,
		   CONCAT(CONVERT(VARCHAR, Size), 'KB') AS Size
	FROM Files
	WHERE RIGHT(Name, LEN(@extension)) = @extension

END

GO

EXEC usp_FindByExtension 'txt'