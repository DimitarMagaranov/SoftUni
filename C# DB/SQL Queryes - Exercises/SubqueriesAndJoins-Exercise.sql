USE SoftUni

SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText FROM Employees AS e
JOIN dbo.Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID

SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText FROM Employees AS e
JOIN dbo.Addresses AS a ON e.AddressID = a.AddressID
JOIN dbo.Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name FROM Employees AS e
JOIN dbo.Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name FROM Employees AS e
JOIN dbo.Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
FULL OUTER JOIN dbo.EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName FROM Employees AS e
JOIN dbo.Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE E.HireDate > '01-01-1999' AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate

SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name FROM Employees AS e
JOIN dbo.EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN dbo.Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate  > '08-13-2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

SELECT e.EmployeeID,
	   e.FirstName, 
	 CASE
			WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
			ELSE p.Name
	 END AS ProjectName
FROM Employees AS e
JOIN dbo.EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN dbo.Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

SELECT e.EmployeeID, e.FirstName, m.EmployeeID AS ManagerID, m.FirstName AS ManagerName FROM Employees AS e
JOIN dbo.Employees AS m ON e.ManagerID = m.EmployeeID
WHERE m.EmployeeID IN (3, 7)
ORDER BY e.EmployeeID

SELECT TOP(50)
e.EmployeeID,
CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
CONCAT(m.FirstName,' ', m.LastName) AS ManagerName,
d.Name AS DepartmentName
FROM Employees AS e
JOIN dbo.Employees AS m ON e.ManagerID = m.EmployeeID
JOIN dbo.Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

SELECT TOP(1) AVG(Salary) AS MinAverageSalary FROM Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary

USE Geography

SELECT c.CountryCode, COUNT(m.MountainRange) FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE c.CountryCode IN ('BG', 'RU', 'US')
GROUP BY c.CountryCode

SELECT TOP(5) c.CountryName, r.RiverName FROM Countries AS c
FULL OUTER JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
FULL OUTER JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

SELECT ContinentCode,
	   CurrencyCode, 
	   CurrencyCount AS [CurrencyUsage]
			FROM (SELECT ContinentCode,
				   CurrencyCode,
				   CurrencyCount,
				   DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS [CurrencyRank]
						FROM (
						   SELECT ContinentCode,
								  CurrencyCode,
								  COUNT(*) AS [CurrencyCount]
						   FROM Countries
						   GROUP BY ContinentCode, CurrencyCode) AS [CurrencyCountQuery]
						   WHERE CurrencyCount > 1
						   ) AS [CurrencyRankingQuery]
WHERE CurrencyRank = 1
ORDER BY ContinentCode


SELECT COUNT(*) AS [Count]
FROM (
		SELECT mc.CountryCode FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		WHERE mc.CountryCode IS NULL
	 ) AS [CountriesWithoutMountains]


SELECT TOP(5) c.CountryName,
			  MAX(p.Elevation) AS [HighestPeakElevation],
			  MAX(r.Length) AS [LongestRiverLength]
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cR.RiverId = r.Id
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, C.CountryName


SELECT TOP(5)  Country,
			   CASE
					WHEN PeakName IS NULL THEN '(no highest peak)'
					ELSE PeakName
			   END AS [Highest Peak Name],
			   CASE
					WHEN Elevation IS NULL THEN 0
					ELSE Elevation
			   END AS [Highest Peak Elevation],
			   CASE
					WHEN MountainRange IS NULL THEN '(no mountain)'
					ELSE MountainRange
			   END AS [Mountain]
			FROM (
					SELECT *,
						   DENSE_RANK() OVER (PARTITION BY Country ORDER BY Elevation DESC) AS [PeakRank]
						 FROM (
			 					SELECT CountryName AS [Country],
			 						   p.PeakName,
			 						   p.Elevation,
			 						   m.MountainRange
			 						FROM Countries AS c
			 					LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
			 					LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
			 					LEFT JOIN Peaks AS p ON m.Id = p.MountainId
			 				 ) AS [FullInfoQuery]
				  ) AS [PeaksRankingQuery]
			WHERE PeakRank = 1
			ORDER BY Country, [Highest Peak Name]
