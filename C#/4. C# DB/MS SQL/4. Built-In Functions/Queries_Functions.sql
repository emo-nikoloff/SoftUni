-- Part I. SoftUni
USE [SoftUni];
GO

-- Задача 1
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [FirstName] LIKE 'Sa%';
GO

-- Задача 2
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [LastName] LIKE '%ei%';
GO

-- Задача 3
SELECT [FirstName]
FROM [Employees]
WHERE [DepartmentID] IN (3, 10)
    AND YEAR([HireDate]) BETWEEN 1995 AND 2005;
GO

-- Задача 4
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [JobTitle] NOT LIKE '%engineer%';
GO

-- Задача 5
SELECT [Name]
FROM [Towns]
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name];
GO

-- Задача 6
SELECT [TownID], [Name]
FROM [Towns]
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name];
GO

-- Задача 7
SELECT [TownID], [Name]
FROM [Towns]
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name];
GO

-- Задача 8
CREATE VIEW [V_EmployeesHiredAfter2000]
AS
    SELECT [FirstName], [LastName]
    FROM [Employees]
    WHERE YEAR([HireDate]) > 2000;
GO

-- Задача 9
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE LEN([LastName]) = 5;
GO

-- Задача 10
SELECT [EmployeeID], [FirstName], [LastName], [Salary], DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC;
GO

-- Задача 11
SELECT *
FROM (SELECT [EmployeeID], [FirstName], [LastName], [Salary], DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
    FROM [Employees]
    WHERE [Salary] BETWEEN 10000 AND 50000) AS [EmployeesRankSalary]
WHERE [Rank] = 2
ORDER BY [Salary] DESC;
GO

-- Part II. Geography
USE [Geography];
GO

-- Задача 12
SELECT [CountryName], [IsoCode]
FROM [Countries]
WHERE LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [IsoCode];
GO

-- Задача 13
SELECT [PeakName], [RiverName], CONCAT(LOWER(LEFT([PeakName], LEN([PeakName]) - 1)), LOWER([RiverName])) AS [Mix]
FROM [Peaks], [Rivers]
WHERE RIGHT([PeakName], 1) = LEFT(LOWER([RiverName]), 1)
ORDER BY [Mix];
GO

-- Part III. Diablo
USE [Diablo];
GO

-- Задача 14
SELECT TOP(50)
    [Name], CONVERT(DATE, [Start]) AS [Start]
FROM [Games]
WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start], [Name];
GO

-- Задача 15
SELECT [Username], RIGHT([Email], LEN([Email]) - CHARINDEX('@', [Email])) AS [Email Provider]
FROM [Users]
ORDER BY [Email Provider], [Username];
GO

-- Задача 16
SELECT [Username], [IpAddress]
FROM [Users]
WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username];
GO

-- Задача 17
SELECT [Name] AS [Game],
    CASE 
        WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
        WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
        WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
    END
    AS [Part of the Day],
    CASE 
        WHEN [Duration] <= 3 THEN 'Extra Short'
        WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
        WHEN [Duration] > 6 THEN 'Long'
        WHEN [Duration] IS NULL THEN 'Extra Long'
    END
    AS [Duration]
FROM [Games]
ORDER BY [Game], [Duration], [Part of the Day];
GO

-- Part IV. Date Functions
CREATE DATABASE [DateFunctions];
GO

USE [DateFunctions];
GO

-- Задача 18
CREATE TABLE [Orders]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [ProductName] VARCHAR(50) NOT NULL,
    [OrderDate] DATETIME2 NOT NULL
);
GO

INSERT INTO [Orders]
    ([ProductName], [OrderDate])
VALUES
    ('Butter', '2016-09-19 00:00:00.000'),
    ('Milk', '2016-09-30 00:00:00.000'),
    ('Cheese', '2016-09-04 00:00:00.000'),
    ('Bread', '2015-12-20 00:00:00.000'),
    ('Tomatoes', '2015-01-01 00:00:00.000');
GO

SELECT [ProductName], [OrderDate], DATEADD(DAY, 3, [OrderDate]) AS [Pay Due], DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
FROM [Orders];
GO

-- Задача 19
CREATE TABLE [People]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [Birthdate] DATETIME2 NOT NULL
);
GO

INSERT INTO [People]
    ([Name], [Birthdate])
VALUES
    ('Victor', '2000-12-07 00:00:00.000'),
    ('Steven', '1992-09-10 00:00:00.000'),
    ('Stephen', '1910-09-19 00:00:00.000'),
    ('John', '2010-01-06 00:00:00.000');
GO

SELECT [Name],
    DATEDIFF(YEAR, [Birthdate], CURRENT_TIMESTAMP) AS [Age in Years],
    DATEDIFF(MONTH, [Birthdate], CURRENT_TIMESTAMP) AS [Age in Months],
    DATEDIFF(DAY, [Birthdate], CURRENT_TIMESTAMP) AS [Age in Days],
    DATEDIFF(MINUTE, [Birthdate], CURRENT_TIMESTAMP) AS [Age in Minutes]
FROM [People];
GO