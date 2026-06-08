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