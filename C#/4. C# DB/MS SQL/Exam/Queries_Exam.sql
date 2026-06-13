-- Section 1. DDL
CREATE DATABASE [EuroLeagues];
GO

USE [EuroLeagues];
GO

-- 1. Database design
CREATE TABLE [Leagues]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Teams]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL UNIQUE,
    [City] NVARCHAR(50) NOT NULL,
    [LeagueId] INT FOREIGN KEY REFERENCES [Leagues](Id) NOT NULL
);
GO

CREATE TABLE [Players]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [Position] NVARCHAR(20) NOT NULL
);
GO

CREATE TABLE [Matches]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [HomeTeamId] INT FOREIGN KEY REFERENCES [Teams](Id) NOT NULL,
    [AwayTeamId] INT FOREIGN KEY REFERENCES [Teams](Id) NOT NULL,
    [MatchDate] DATETIME2 NOT NULL,
    [HomeTeamGoals] INT NOT NULL DEFAULT 0,
    [AwayTeamGoals] INT NOT NULL DEFAULT 0,
    [LeagueId] INT FOREIGN KEY REFERENCES [Leagues](Id) NOT NULL,
);
GO

CREATE TABLE [PlayersTeams]
(
    [PlayerId] INT FOREIGN KEY REFERENCES [Players](Id) NOT NULL,
    [TeamId] INT FOREIGN KEY REFERENCES [Teams](Id) NOT NULL,
        PRIMARY KEY([PlayerId], [TeamId])
);
GO

CREATE TABLE [PlayerStats]
(
    [PlayerId] INT FOREIGN KEY REFERENCES [Players](Id) NOT NULL,
    [Goals] INT NOT NULL DEFAULT 0,
    [Assists] INT NOT NULL DEFAULT 0
        PRIMARY KEY([PlayerId])
);
GO

CREATE TABLE [TeamStats]
(
    [TeamId] INT FOREIGN KEY REFERENCES [Teams](Id) NOT NULL,
    [Wins] INT NOT NULL DEFAULT 0,
    [Draws] INT NOT NULL DEFAULT 0,
    [Losses] INT NOT NULL DEFAULT 0
        PRIMARY KEY([TeamId])
);
GO

-- Section 2. DML (using DataSet.sql)
-- 2. Insert 
INSERT INTO [Leagues]
    ([Name])
VALUES
    ('Eredivisie');

INSERT INTO [Teams]
    ([Name], [City], [LeagueId])
VALUES
    ('PSV', 'Eindhoven', (SELECT [Id]
        FROM [Leagues]
        WHERE [Name] = 'Eredivisie')),
    ('Ajax', 'Amsterdam', (SELECT [Id]
        FROM [Leagues]
        WHERE [Name] = 'Eredivisie'));

INSERT INTO [Players]
    ([Name], [Position])
VALUES
    ('Luuk de Jong', 'Forward'),
    ('Josip Sutalo', 'Defender');

INSERT INTO [Matches]
    ([HomeTeamId], [AwayTeamId], [MatchDate], [HomeTeamGoals], [AwayTeamGoals], [LeagueId])
VALUES
    (
    (SELECT [Id]
        FROM [Teams]
        WHERE [Name] = 'Ajax'),
    (SELECT [Id]
        FROM [Teams]
        WHERE [Name] = 'PSV'),
    '2024-11-02 20:45:00',
    3,
    2,
    (SELECT [Id]
        FROM [Leagues]
        WHERE [Name] = 'Eredivisie')
);

INSERT INTO [PlayersTeams]
    ([PlayerId], [TeamId])
VALUES
    ((SELECT [Id]
        FROM [Players]
        WHERE [Name] = 'Luuk de Jong'), 
    (SELECT [Id]
        FROM [Teams]
        WHERE [Name] = 'PSV')),
    ((SELECT [Id]
        FROM [Players]
        WHERE [Name] = 'Josip Sutalo'), 
    (SELECT [Id]
        FROM [Teams]
        WHERE [Name] = 'Ajax'));

INSERT INTO [PlayerStats]
    ([PlayerId], [Goals], [Assists])
VALUES
    ((SELECT [Id]
        FROM [Players]
        WHERE [Name] = 'Luuk de Jong'), 2, 0),
    ((SELECT [Id]
        FROM [Players]
        WHERE [Name] = 'Josip Sutalo'), 2, 0);

INSERT INTO [TeamStats]
    ([TeamId], [Wins], [Draws], [Losses])
VALUES
    ((SELECT [Id]
        FROM [Teams]
        WHERE [Name] = 'PSV'), 15, 1, 3),
    ((SELECT [Id]
        FROM [Teams]
        WHERE [Name] = 'Ajax'), 14, 3, 2);

-- 3. Update
UPDATE [PlayerStats]
SET [Goals] += 1
FROM [PlayerStats] AS [ps]
    JOIN [Players] AS [p] ON [p].[Id] = [ps].[PlayerId]
    JOIN [PlayersTeams] AS [pt] ON [pt].[PlayerId] = [p].[Id]
    JOIN [Teams] AS [t] ON [t].[Id] = [pt].[TeamId]
    JOIN [Leagues] AS [l] ON [l].[Id] = [t].[LeagueId]
WHERE [p].[Position] = 'Forward'
    AND [l].[Name] = 'La Liga'

-- 4. Delete
DELETE [ps]
FROM [PlayerStats] AS [ps]
    JOIN [Players] AS [p] ON [p].[Id] = [ps].[PlayerId]
    JOIN [PlayersTeams] AS [pt] ON [pt].[PlayerId] = [p].[Id]
    JOIN [Teams] AS [t] ON [t].[Id] = [pt].[TeamId]
    JOIN [Leagues] AS [l] ON [l].[Id] = [t].[LeagueId]
WHERE [p].[Name] IN ('Luuk de Jong', 'Josip Sutalo')
    AND [l].[Name] = 'Eredivisie';
GO

DELETE [pt]
FROM [PlayersTeams] AS [pt]
    JOIN [Players] AS [p] ON [p].[Id] = [pt].[PlayerId]
    JOIN [Teams] AS [t] ON [t].[Id] = [pt].[TeamId]
    JOIN [Leagues] AS [l] ON [l].[Id] = [t].[LeagueId]
WHERE [p].[Name] IN ('Luuk de Jong', 'Josip Sutalo')
    AND [l].[Name] = 'Eredivisie';
GO

DELETE [p]
FROM [Players] AS [p]
WHERE [p].[Name] IN ('Luuk de Jong', 'Josip Sutalo');
GO

-- Section 3. Querying
-- 5. Matches by Goals and Date
SELECT 
    CONVERT(VARCHAR(10), [MatchDate], 120) AS [MatchDate], 
    [HomeTeamGoals], 
    [AwayTeamGoals], 
    ([HomeTeamGoals] + [AwayTeamGoals]) AS [TotalGoals]
FROM [Matches]
WHERE ([HomeTeamGoals] + [AwayTeamGoals]) >= 5
ORDER BY [TotalGoals] DESC, [MatchDate];
GO

-- 6. Players with Common Part in Their Names
SELECT [p].[Name], [t].[City]
FROM [Players] AS [p]
    JOIN [PlayersTeams] AS [pt] ON [pt].[PlayerId] = [p].[Id]
    JOIN [Teams] AS [t] ON [t].[Id] = [pt].[TeamId]
WHERE [p].[Name] LIKE '%Aaron%'
ORDER BY [p].[Name];
GO

-- 7. Players in Teams Situated in London
SELECT [p].[Id], [p].[Name], [p].[Position]
FROM [PlayersTeams] AS [pt]
    JOIN [Players] AS [p] ON [p].[Id] = [pt].[PlayerId]
    JOIN [Teams] AS [t] ON [t].[Id] = [pt].[TeamId]
WHERE [t].[City] = 'London'
ORDER BY [p].[Name];
GO

-- 8. First 10 Matches in Early September
SELECT TOP(10)
    [ht].[Name] AS [HomeTeamName],
    [at].[Name] AS [AwayTeamName],
    [l].[Name] AS [LeagueName],
    CONVERT(VARCHAR(10), [MatchDate]) AS [MatchDate]
FROM [Matches] AS [m]
    JOIN [Teams] AS [ht] ON [ht].[Id] = [m].[HomeTeamId]
    JOIN [Teams] AS [at] ON [at].[Id] = [m].[AwayTeamId]
    JOIN [Leagues] AS [l] ON [l].[Id] = [m].[LeagueId]
WHERE [m].[MatchDate] BETWEEN '2024-09-01' AND '2024-09-15'
    AND [l].[Id] % 2 = 0
ORDER BY [m].[MatchDate], [HomeTeamName];
GO

-- 9. Best Guest Teams
SELECT 
    [t].[Id],
    [t].[Name],
    SUM([m].[AwayTeamGoals]) AS [TotalAwayGoals]
FROM [Teams] AS [t]
    JOIN [Matches] AS [m] ON [m].[AwayTeamId] = [t].[Id]
GROUP BY [t].[Id], [t].[Name]
HAVING SUM([m].[AwayTeamGoals]) >= 6
ORDER BY [TotalAwayGoals] DESC, [t].[Name];
GO

-- 10. Average Scoring Rate
SELECT 
    [l].[Name] AS [LeagueName],
    ROUND((SUM([m].[HomeTeamGoals]) + SUM([m].[AwayTeamGoals])) / CAST(COUNT([m].[Id]) AS FLOAT), 2) AS [AvgScoringRate]
FROM [Matches] AS [m]
    JOIN [Teams] AS [t] ON [t].[Id] = [m].[HomeTeamId]
    JOIN [Teams] AS [at] ON [at].[Id] = [m].[AwayTeamId]
    JOIN [Leagues] AS [l] ON [l].[Id] = [m].[LeagueId]
GROUP BY [l].[Name]
ORDER BY [AvgScoringRate] DESC;
GO

-- 11. League Top Scorer
CREATE FUNCTION [udf_LeagueTopScorer]
    (@leagueName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT [Name], [TotalGoals]
    FROM
    (
        SELECT 
            [p].[Name], 
            [ps].[Goals] AS [TotalGoals],
            DENSE_RANK() OVER (ORDER BY [ps].[Goals] DESC) AS [Rank]
        FROM [Players] AS [p]
            JOIN [PlayerStats] AS [ps] ON [ps].[PlayerId] = [p].[Id]
            JOIN [PlayersTeams] AS [pt] ON [pt].[PlayerId] = [p].[Id]
            JOIN [Teams] AS [t] ON [t].[Id] = [pt].[TeamId]
            JOIN [Leagues] AS [l] ON [l].[Id] = [t].[LeagueId]
        WHERE [l].[Name] = @leagueName
    ) AS [RankedScorers]
    WHERE [Rank] = 1
);
GO

-- 12. Update Player Stats
CREATE PROCEDURE [usp_UpdatePlayerStats]
    (@playerId INT,
    @goalsDelta INT = NULL,
    @assistsDelta INT = NULL)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [PlayerStats] WHERE [PlayerId] = @playerId)
    BEGIN
        INSERT INTO [PlayerStats]
            ([PlayerId], [Goals], [Assists])
        VALUES
            (@playerId, ISNULL(@goalsDelta, 0), ISNULL(@assistsDelta, 0));
    END
    ELSE
    BEGIN
        UPDATE [PlayerStats]
        SET 
            [Goals] = [Goals] + ISNULL(@goalsDelta, 0),
            [Assists] = [Assists] + ISNULL(@assistsDelta, 0)
        WHERE [PlayerId] = @playerId;
    END
END
GO