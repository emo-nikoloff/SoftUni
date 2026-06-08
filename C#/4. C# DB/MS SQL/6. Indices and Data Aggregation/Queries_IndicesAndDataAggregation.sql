-- Part I. Gringotts
USE [Gringotts];
GO

-- Задача 1
SELECT COUNT(*) AS [Count]
FROM [WizzardDeposits];
GO

-- Задача 2
SELECT MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits];
GO

-- Задача 3
SELECT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits]
GROUP BY [DepositGroup];
GO

-- Задача 4
SELECT TOP(2)
    [DepositGroup]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize]);
GO

-- Задача 5
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
GROUP BY [DepositGroup];
GO

-- Задача 6
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup];
GO

-- Задача 7
SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC;
GO

-- Задача 8
SELECT [DepositGroup], [MagicWandCreator], MIN([DepositCharge]) AS [MinDepositCharge]
FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup];
GO

-- Задача 9
SELECT [AgeGroup], COUNT([Id]) AS [WizarCount]
FROM(SELECT *,
        CASE
            WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
            WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
            WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
            WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
            WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
            WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
            WHEN [Age] >= 61 THEN '[61+]'
        END AS [AgeGroup]
    FROM [WizzardDeposits]) AS [AgeGroupingQuery]
GROUP BY [AgeGroup];
GO

-- Задача 10
SELECT LEFT([FirstName], 1) AS [FirstLetter]
FROM [WizzardDeposits]
WHERE [DepositGroup] = 'Troll Chest'
GROUP BY LEFT([FirstName], 1)
ORDER BY [FirstLetter];
GO

-- Задача 11
SELECT [DepositGroup], [IsDepositExpired], AVG([DepositInterest])
FROM [WizzardDeposits]
WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired];
GO

-- Задача 12
SELECT SUM([Difference])
FROM(SELECT
        [h].[FirstName] AS [Host Wizard],
        [h].[DepositAmount] AS [Host Wizard Deposit],
        [g].[FirstName] AS [Guest Wizard],
        [g].[DepositAmount] AS [Guest Wizard Deposit],
        [h].[DepositAmount] - [g].[DepositAmount] AS [Difference]
    FROM [WizzardDeposits] AS [h]
        JOIN [WizzardDeposits] AS [g] ON [g].[Id] = [h].[Id] + 1) AS [DifferenceQuery];
GO

-- Part II. SoftUni
USE [SoftUni];
GO

-- Задача 13
SELECT [DepartmentID], SUM([Salary]) AS [TotalSalary]
FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID];
GO

-- Задача 14
SELECT [DepartmentID], MIN([Salary]) AS [MinimumSalary]
FROM [Employees]
WHERE [DepartmentID] IN (2, 5, 7)
    AND [HireDate] > '01/01/2000'
GROUP BY [DepartmentID]
ORDER BY [DepartmentID];
GO

-- Задача 15
SELECT *
INTO [#EmployeesHighSalaryTempTable]
FROM [Employees]
WHERE [Salary] > 30000;
GO

DELETE FROM [#EmployeesHighSalaryTempTable]
WHERE [ManagerID] = 42;
GO

UPDATE [#EmployeesHighSalaryTempTable]
SET [Salary] += 5000
WHERE [DepartmentID] = 1;
GO

SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary]
FROM [#EmployeesHighSalaryTempTable]
GROUP BY [DepartmentID];
GO

-- Задача 16
SELECT [DepartmentID], MAX([Salary]) AS [MaxSalary]
FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000;
GO

-- Задача 17
SELECT COUNT([Salary]) AS [Count]
FROM [Employees]
WHERE [ManagerID] IS NULL;
GO

-- Задача 18
SELECT DISTINCT [DepartmentID], [Salary] AS [ThirdHighestSalary]
FROM(SELECT [EmployeeID], CONCAT_WS(' ', [FirstName], [LastName]) AS [FullName], [DepartmentID], [Salary],
        DENSE_RANK() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [SalaryRank]
    FROM [Employees]) AS [SalaryRankQuery]
WHERE [SalaryRank] = 3;
GO

-- Задача 19
SELECT TOP(10)
    [FirstName], [LastName], [DepartmentID]
FROM [Employees] AS [e]
WHERE [e].[Salary] > (
                SELECT AVG([Salary])
FROM [Employees]
WHERE [DepartmentID] = [e].[DepartmentID])
ORDER BY [e].[DepartmentID];
GO