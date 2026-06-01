-- Part I. SoftUni
USE [SoftUni];
GO

-- Задача 1
SELECT TOP(5)
    [e].[EmployeeID], [e].[JobTitle], [e].[AddressID], [a].[AddressText]
FROM [Employees] AS [e]
    JOIN [Addresses] AS [a] ON [a].[AddressID] = [e].[AddressID]
ORDER BY [e].[AddressID];
GO

-- Задача 2
SELECT TOP(50)
    [e].[FirstName], [e].[LastName], [t].[Name] AS [Town], [a].[AddressText]
FROM [Employees] AS [e]
    JOIN [Addresses] AS [a] ON [a].[AddressID] = [e].[AddressID]
    JOIN [Towns] AS [t] ON [t].[TownID] = [a].[TownID]
ORDER BY [e].[FirstName], [e].[LastName];
GO

-- Задача 3
SELECT
    [e].[EmployeeID], [e].[FirstName], [e].[LastName], [d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
    JOIN [Departments] AS [d] ON [d].[DepartmentID] = [e].[DepartmentID]
WHERE [d].[Name] = 'Sales'
ORDER BY [e].[EmployeeID];
GO

-- Задача 4
SELECT TOP(5)
    [e].[EmployeeID], [e].[FirstName], [e].[Salary], [d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
    JOIN [Departments] AS [d] ON [d].[DepartmentID] = [e].[DepartmentID]
WHERE [e].[Salary] > 15000
ORDER BY [e].[DepartmentID];
GO

-- Задача 5
SELECT TOP(3)
    [e].[EmployeeID], [e].[FirstName]
FROM [EmployeesProjects] AS [ep]
    RIGHT JOIN [Employees] AS [e] ON [ep].[EmployeeID] = [e].[EmployeeID]
WHERE [ep].[EmployeeID] IS NULL
ORDER BY [e].[EmployeeID];
GO

-- Задача 6
SELECT
    [e].[FirstName], [e].[LastName], [e].[HireDate], [d].[Name] AS [DeptName]
FROM [Employees] AS [e]
    JOIN [Departments] AS [d] ON [d].[DepartmentID] = [e].[DepartmentID]
WHERE [e].[HireDate] > DATEFROMPARTS(1999, 1, 1)
    AND [d].[Name] IN ('Sales', 'Finance')
ORDER BY [e].[HireDate];
GO

-- Задача 7
SELECT TOP(5)
    [e].[EmployeeID], [e].[FirstName], [p].[Name] AS [ProjectName]
FROM [EmployeesProjects] AS [ep]
    JOIN [Employees] AS [e] ON [e].[EmployeeID] = [ep].[EmployeeID]
    JOIN [Projects] AS [p] ON [p].[ProjectID] = [ep].[ProjectID]
WHERE [p].[StartDate] > DATEFROMPARTS(2002, 8, 13)
    AND [p].[EndDate] IS NULL
ORDER BY [e].[EmployeeID];
GO

-- Задача 8
SELECT
    [e].[EmployeeID], [e].[FirstName],
    CASE
        WHEN YEAR([p].[StartDate]) >= 2005 THEN NULL
        ELSE [p].[Name]
    END
    AS [ProjectName]
FROM [EmployeesProjects] AS [ep]
    JOIN [Employees] AS [e] ON [e].[EmployeeID] = [ep].[EmployeeID]
    JOIN [Projects] AS [p] ON [p].[ProjectID] = [ep].[ProjectID]
WHERE [e].[EmployeeID] = 24;
GO

-- Задача 9
SELECT [e].[EmployeeID], [e].[FirstName], [e].[ManagerID], [m].[FirstName] AS [ManagerName]
FROM [Employees] AS [e]
    JOIN [Employees] AS [m] ON [m].[EmployeeID] = [e].[ManagerID]
WHERE [e].[ManagerID] IN (3 ,7)
ORDER BY [e].[EmployeeID];
GO

-- Задача 10
SELECT TOP(50)
    [e].[EmployeeID],
    CONCAT_WS(' ', [e].[FirstName], [e].[LastName]) AS [EmployeeName],
    CONCAT_WS(' ', [m].[FirstName], [m].[LastName]) AS [ManagerName],
    [d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
    LEFT JOIN [Employees] AS [m] ON [m].[EmployeeID] = [e].[ManagerID]
    JOIN [Departments] AS [d] ON [d].[DepartmentID] = [e].[DepartmentID]
ORDER BY [e].[EmployeeID];
GO

-- Задача 11
SELECT MIN([AvgSalary]) AS [MinAverageSalary]
FROM(
    SELECT AVG([Salary]) AS [AvgSalary]
    FROM [Employees]
    GROUP BY [DepartmentID]
) AS [TempTable];

-- Part II. Geography
USE [Geography];
GO

-- Задача 12
SELECT [mc].[CountryCode], [m].[MountainRange], [p].[PeakName], [p].[Elevation]
FROM [MountainsCountries] AS [mc]
    JOIN [Mountains] AS [m] ON [m].[Id] = [mc].[MountainId]
    JOIN [Peaks] AS [p] ON [p].[MountainId] = [m].[Id]
WHERE [mc].[CountryCode] = 'BG'
    AND [p].[Elevation] > 2835
ORDER BY [p].[Elevation] DESC;
GO

-- Задача 13
SELECT [mc].[CountryCode], COUNT([m].[MountainRange]) AS [MountainRanges]
FROM [MountainsCountries] AS [mc]
    JOIN [Mountains] AS [m] ON [m].[Id] = [mc].[MountainId]
WHERE [mc].[CountryCode] IN ('US', 'RU', 'BG')
GROUP BY [mc].[CountryCode];
GO

-- Задача 14
SELECT TOP (5)
    [c].[CountryName], [r].[RiverName]
FROM [Countries] AS [c]
    JOIN [Continents] AS [cont] ON [c].[ContinentCode] = [cont].[ContinentCode]
    LEFT JOIN [CountriesRivers] AS [cr] ON [c].[CountryCode] = [cr].[CountryCode]
    LEFT JOIN [Rivers] AS [r] ON [cr].[RiverId] = [r].[Id]
WHERE [cont].[ContinentName] = 'Africa'
ORDER BY [c].[CountryName];
GO

-- Задача 15
WITH
    [CurrencyUsageResult]
    AS
    (
        SELECT [ContinentCode], [CurrencyCode], COUNT([CurrencyCode]) AS [CurrencyUsage]
        FROM [Countries]
        GROUP BY [ContinentCode], [CurrencyCode]
        HAVING COUNT([CurrencyCode]) > 1
    )

SELECT [ContinentCode], [CurrencyCode], [CurrencyUsage]
FROM (
    SELECT *, DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC) AS [CurrencyRank]
    FROM [CurrencyUsageResult]
) AS [CurrencyRankingQuery]
WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode];

-- Задача 16
SELECT COUNT(*) AS [Count]
FROM [Countries] AS [c]
    LEFT JOIN [MountainsCountries] AS [mc] ON [mc].[CountryCode] = [c].[CountryCode]
WHERE [mc].[MountainId] IS NULL;

-- Задача 17
SELECT TOP(5)
    [c].[CountryName], MAX([p].[Elevation]) AS [HighestPeakElevation], MAX([r].[Length]) AS [LongestRiverLength]
FROM [Countries] AS [c]
    LEFT JOIN [MountainsCountries] AS [mc] ON [mc].[CountryCode] = [c].[CountryCode]
    LEFT JOIN [Peaks] AS [p] ON [p].[MountainId] = [mc].[MountainId]
    LEFT JOIN [CountriesRivers] AS [cr] ON [cr].[CountryCode] = [c].[CountryCode]
    LEFT JOIN [Rivers] AS [r] ON [r].[Id] = [cr].[RiverId]
GROUP BY [c].[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [c].[CountryName];
GO

-- Задача 18
SELECT TOP(5)
    [CountryName] AS [Country],
    ISNULL([PeakName], '(no highest peak)') AS [Highest Peak Name],
    ISNULL([Elevation], 0) AS [Highest Peak Elevation],
    ISNULL([MountainRange], '(no mountain)') AS [Mountain]
FROM(
    SELECT [c].[CountryName], [p].[PeakName], [p].[Elevation], [m].[MountainRange],
        DENSE_RANK() OVER (PARTITION BY [c].[CountryCode] ORDER BY [p].[Elevation] DESC) AS [PeakRank]
    FROM [Countries] AS [c]
        LEFT JOIN [MountainsCountries] AS [mc] ON [mc].[CountryCode] = [c].[CountryCode]
        LEFT JOIN [Mountains] AS [m] ON [m].[Id] = [mc].[MountainId]
        LEFT JOIN [Peaks] AS [p] ON [p].[MountainId] = [m].[Id]
) AS [CountryPeaksRankQuery]
WHERE [PeakRank] = 1
ORDER BY [Country], [PeakName];
GO