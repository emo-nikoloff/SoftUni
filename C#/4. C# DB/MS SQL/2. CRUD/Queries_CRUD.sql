-- Part I. SoftUni
USE [SoftUni];
GO

-- Задача 2
SELECT *
FROM [Departments];
GO

-- Задача 3
SELECT [Name]
FROM [Departments];
GO

-- Задача 4
SELECT [FirstName], [LastName], [Salary]
FROM [Employees];
GO

-- Задача 5
SELECT [FirstName], [LastName], [Salary]
FROM [Employees];
GO

-- Задача 6
SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' AS [Full Email Address]
FROM [Employees];
GO

-- Задача 7
SELECT DISTINCT [Salary]
FROM [Employees];
GO

-- Задача 8
SELECT *
FROM [Employees]
WHERE [JobTitle] = 'Sales Representative';
GO

-- Задача 9
SELECT [FirstName], [LastName], [JobTitle]
FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000;
GO

-- Задача 10
SELECT CONCAT_WS(' ', [FirstName], [MiddleName], [LastName]) AS [Full Name]
FROM [Employees]
WHERE [Salary] IN (25000, 14000, 12500, 23600);
GO

-- Задача 11
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [ManagerID] IS NULL;
GO

-- Задача 12
SELECT [FirstName], [LastName], [Salary]
FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC;
GO

-- Задача 13
SELECT TOP(5)
    [FirstName], [LastName]
FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC;
GO

-- Задача 14
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [DepartmentID] != 4;
GO

-- Задача 15
SELECT *
FROM [Employees]
ORDER BY [Salary] DESC, [FirstName], [LastName] DESC, [MiddleName];
GO

-- Задача 16
CREATE VIEW [V_EmployeesSalaries]
AS
    SELECT [FirstName], [LastName], [Salary]
    FROM [Employees];
GO

SELECT *
FROM V_EmployeesSalaries;
GO

-- Задача 17
CREATE VIEW [V_EmployeeNameJobTitle]
AS
    SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name], [JobTitle]
    FROM [Employees]
GO

SELECT *
FROM V_EmployeeNameJobTitle;
Go

-- Задача 18
SELECT DISTINCT [JobTitle]
FROM [Employees];
GO

-- Задача 19
SELECT TOP(10)
    *
FROM [Projects]
ORDER BY [StartDate], [Name];
GO

-- Задача 20
SELECT TOP(7)
    [FirstName], [LastName], [HireDate]
FROM [Employees]
ORDER BY [HireDate] DESC;
GO

-- Задача 21
UPDATE [Employees]
SET [Salary] += [Salary] * 0.12
WHERE [DepartmentID] IN (
SELECT [DepartmentID]
FROM [Departments]
WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
)
GO

SELECT [Salary]
FROM [Employees];
GO

-- Part II. Geography
USE [Geography];
GO

-- Задача 22
SELECT [PeakName]
FROM [Peaks]
ORDER BY [PeakName];
GO

-- Задача 23
SELECT TOP(30)
    [CountryName], [Population]
FROM [Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC, [CountryName];
GO

-- Задача 24
SELECT [CountryName], [CountryCode],
    CASE
        WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
        ELSE 'Not Euro'
    END
    AS [Currency]
FROM [Countries]
ORDER BY [CountryName];
GO


-- Part III. Diablo
USE [Diablo];
GO

-- Задача 25
SELECT [Name]
FROM [Characters]
ORDER BY [Name];
GO