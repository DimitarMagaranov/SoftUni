USE Gringotts

SELECT COUNT(*) AS [Count] FROM WizzardDeposits

SELECT MAX(MagicWandSize) AS [LongestMagicWand] FROM WizzardDeposits

SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand] FROM WizzardDeposits
GROUP BY DepositGroup

SELECT TOP(2) DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
GROUP BY DepositGroup

SELECT * FROM (		
				SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
					GROUP BY DepositGroup, MagicWandCreator
					HAVING MagicWandCreator = 'Ollivander family'
			  ) AS [DepositFilteredQuery]
WHERE TotalSum < 150000
ORDER BY TotalSum DESC

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [MinDepositCharge] FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

SELECT AgeGroup,
	   COUNT(*) AS [WizardCount] FROM(
										SELECT 
											  CASE
									  			   WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
									  			   WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
									  			   WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
									  			   WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
									  			   WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
									  			   WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
									  			   ELSE '[61+]'
											  END AS [AgeGroup]
										FROM WizzardDeposits
									  ) AS [SubQuery]
GROUP BY AgeGroup

SELECT * FROM (
				SELECT LEFT(FirstName, 1) AS [FirstLetter] FROM WizzardDeposits
				WHERE DepositGroup = 'Troll Chest'
			  ) AS [SubQuery]
GROUP BY FirstLetter

SELECT DepositGroup,
	   IsDepositExpired,
	   AVG(DepositInterest) AS [AverageInterest] 
			FROM (
				   SELECT * FROM WizzardDeposits
				   WHERE DepositStartDate > '01-01-1985'
				 ) AS [SubQuery]
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

SELECT SUM([Difference]) AS [SumDifference]
FROM (
	   SELECT FirstName AS [Host Wizard],
	          DepositAmount AS [Host Wizard Deposit],
	          LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
	          LEAD(DepositAmount) OVER(ORDER BY Id) [Guest Wizard Deposit],
	          DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
       FROM WizzardDeposits
	 ) AS [DepositDifferenceQuery]
WHERE [Guest Wizard] IS NOT NULL

USE SoftUni

SELECT DepartmentID, MIN(Salary) AS [MinimumSalary] FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '01-01-2000'
GROUP BY DepartmentID


SELECT * INTO EmployeesWithHighSalary FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalary
WHERE ManagerID = 42

UPDATE EmployeesWithHighSalary
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS [AverageSalary] FROM EmployeesWithHighSalary
GROUP BY DepartmentID


SELECT DepartmentID, MAX(Salary) AS [MaxSalary] FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

SELECT COUNT(Salary) AS [Count] FROM Employees
WHERE ManagerID IS NULL

SELECT DepartmentID,
	   Salary AS [ThirdHighestSalary]
FROM 
	(
	 SELECT DISTINCT DepartmentID,
	 Salary,
	 DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [SalaryRank]
	 FROM Employees
	) AS [RankingQuery]
WHERE SalaryRank = 3


SELECT DepartmentID,
	   AVG(Salary) AS [AvgSalary]
FROM Employees
GROUP BY DepartmentID

SELECT TOP(10) e1.FirstName,
			   e1.LastName,
			   e1.DepartmentID
FROM Employees AS e1
WHERE e1.Salary > (SELECT AVG(Salary) AS [AverageSalary]
				    FROM Employees AS e2
					WHERE e2.DepartmentID = e1.DepartmentID
				    GROUP BY DepartmentID
				  )
ORDER BY DepartmentID


SELECT DepartmentID,
	   AVG(Salary) AS [AvgSalary]
INTO DepartmentsWithAverageSalaries
FROM Employees
GROUP BY DepartmentID

SELECT TOP(10) FirstName,
	           LastName,
	           e.DepartmentID
FROM Employees AS e
JOIN DepartmentsWithAverageSalaries AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > d.AvgSalary
ORDER BY DepartmentID



