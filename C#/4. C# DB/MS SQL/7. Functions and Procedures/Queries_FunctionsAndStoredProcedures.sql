-- Part I. SoftUni
USE [SoftUni];
GO

-- Задача 1
CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000]
AS
BEGIN
    SELECT [FirstName], [LastName]
    FROM [Employees]
    WHERE [Salary] > 35000;
END
GO

EXEC [usp_GetEmployeesSalaryAbove35000];
GO

-- Задача 2
CREATE PROCEDURE [usp_GetEmployeesSalaryAboveNumber]
    (@Number DECIMAL(18, 4))
AS
BEGIN
    SELECT [FirstName], [LastName]
    FROM [Employees]
    WHERE [Salary] >= @Number;
END
GO

EXEC [usp_GetEmployeesSalaryAboveNumber] 48100;
GO

-- Задача 3
CREATE PROCEDURE [usp_GetTownsStartingWith]
    (@StartString VARCHAR(50))
AS
BEGIN
    SELECT [Name] AS [Town]
    FROM [Towns]
    WHERE LOWER([Name]) LIKE LOWER(@StartString) + '%';
END
GO

EXEC [usp_GetTownsStartingWith] 'B';
GO

-- Задача 4
CREATE PROCEDURE [usp_GetEmployeesFromTown]
    (@TownName VARCHAR(50))
AS
BEGIN
    SELECT [FirstName], [LastName]
    FROM [Employees] AS [e]
        JOIN [Addresses] AS [a] ON [a].[AddressID] = [e].[AddressID]
        JOIN [Towns] AS [t] ON [t].[TownID] = [a].[TownID]
    WHERE [t].[Name] = @TownName;
END
GO

EXEC [usp_GetEmployeesFromTown] 'Sofia';
GO

-- Задача 5
CREATE FUNCTION [ufn_GetSalaryLevel]
    (@Salary DECIMAL(18, 4))
    RETURNS VARCHAR(7)
AS
BEGIN
    DECLARE @SalaryLevel VARCHAR(7);

    SET @SalaryLevel = CASE 
        WHEN @Salary < 30000 THEN 'Low'
        WHEN @Salary <= 50000 THEN 'Average'
        ELSE 'High'
    END;

    RETURN @SalaryLevel;
END
GO

SELECT [Salary], [dbo].[ufn_GetSalaryLevel]([Salary]) AS [Salary Level]
FROM [Employees];
GO

-- Задача 6
CREATE PROCEDURE [usp_EmployeesBySalaryLevel]
    (@SalaryLevel VARCHAR(7))
AS
BEGIN
    SELECT [FirstName], [LastName]
    FROM [Employees]
    WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = 'High';
END
GO

EXEC [usp_EmployeesBySalaryLevel] 'High';
GO

-- Задача 7
CREATE FUNCTION [ufn_IsWordComprised]
    (@SetOfLetters VARCHAR(26),
    @Word VARCHAR(50))
    RETURNS BIT
AS
BEGIN
    DECLARE @Checker BIT;

    BEGIN
        IF(@Word LIKE CONCAT('%[^', @SetOfLetters, ']%'))
            SET @Checker = 0;
        ELSE 
            SET @Checker = 1;
    END

    RETURN @Checker;
END
GO

SELECT [Name], [dbo].[ufn_IsWordComprised]('oistmiahf', [Name]) AS [Result]
FROM [Towns]
GO

-- Задача 8
CREATE PROCEDURE [usp_DeleteEmployeesFromDepartment]
    (@departmentId INT)
AS
BEGIN
    WITH
        [EmployeesToDeleteIdsCTE]
        AS

        (
            SELECT [EmployeeID]
            FROM [Employees]
            WHERE [DepartmentID] = @departmentId
        )
    
    DELETE 
    FROM [EmployeesProjects]
    WHERE [EmployeeID] IN (SELECT [EmployeeID]
    FROM [EmployeesToDeleteIdsCTE])

    ALTER TABLE [Departments]
    ALTER COLUMN [ManagerID] INT

    UPDATE [Departments]
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (SELECT [EmployeeID]
    FROM [Employees]
    WHERE [DepartmentID] = @departmentId)

    UPDATE [Employees]
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (SELECT [EmployeeID]
    FROM [Employees]
    WHERE [DepartmentID] = @departmentId)

    DELETE
    FROM [Employees]
    WHERE [DepartmentID] = @departmentId

    DELETE
    FROM [Departments]
    WHERE [DepartmentID] = @departmentId

    SELECT COUNT(*)
    FROM [Employees]
    WHERE [DepartmentID] = @departmentId
END
GO

-- Part II. Bank
USE [Bank];
GO

-- Задача 9
CREATE PROCEDURE [usp_GetHoldersFullName]
AS
BEGIN
    SELECT CONCAT_WS(' ', [FirstName], [LastName]) AS [Full Name]
    FROM [AccountHolders];
END
GO

EXEC [usp_GetHoldersFullName];
GO

-- Задача 10
CREATE PROCEDURE [usp_GetHoldersWithBalanceHigherThan]
    (@Balance DECIMAL(18, 4))
AS
BEGIN
    SELECT [ah].[FirstName], [ah].[LastName]
    FROM [Accounts] AS [a]
        JOIN [AccountHolders] AS [ah] ON [ah].[Id] = [a].[AccountHolderId]
    GROUP BY [ah].[FirstName], [ah].[LastName]
    HAVING SUM([a].[Balance]) > @Balance
    ORDER BY [FirstName], [LastName]
END
GO

-- Задача 11
CREATE FUNCTION [ufn_CalculateFutureValue] 
    (@Sum DECIMAL(18, 4),
    @Rate FLOAT,
    @PeriodYears INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
    RETURN @Sum * (POWER((1 + @Rate), @PeriodYears));
END
GO

-- Задача 12
CREATE PROCEDURE [usp_CalculateFutureValueForAccount]
    (@AccountId INT,
    @Rate FLOAT)
AS
BEGIN
    SELECT [a].[Id] AS [Account Id],
        [ah].[FirstName] AS [First Name],
        [ah].[LastName] AS [Last Name],
        [a].[Balance] AS [Current Balance],
        [dbo].[ufn_CalculateFutureValue]([a].[Balance], @Rate, 5) AS [Balance in 5 years]
    FROM [Accounts] AS [a]
        JOIN [AccountHolders] AS [ah] ON [ah].[Id] = [a].[AccountHolderId]
    WHERE [a].[Id] = @AccountId;
END
GO

-- Part III. Diablo
-- Задача 13
CREATE FUNCTION [ufn_CashInUsersGames]
    (@GameName NVARCHAR(50))
RETURNS TABLE
AS
    RETURN(SELECT SUM([Cash]) AS [SumCash]
FROM(
    SELECT [g].[Name], [ug].[Cash], ROW_NUMBER() OVER(ORDER BY [ug].[Cash] DESC) AS [RowNumber]
    FROM [UsersGames] AS [ug]
        JOIN [Games] AS [g] ON [g].[Id] = [ug].[GameId]
    WHERE [g].[Name] = @GameName
    ) AS [RowNumberRankingQuery]
WHERE [RowNumber] % 2 != 0)
GO