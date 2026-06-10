-- Section 1. DDL
CREATE DATABASE [LibraryDb];
GO

USE [LibraryDb];
GO

-- 1. Database design
CREATE TABLE [Contacts]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Email] NVARCHAR(100),
    [PhoneNumber] NVARCHAR(20),
    [PostAddress] NVARCHAR(200),
    [Website] NVARCHAR(50)
);
GO

CREATE TABLE [Authors]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [ContactId] INT FOREIGN KEY REFERENCES [Contacts](Id) NOT NULL
);
GO

CREATE TABLE [Genres]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(30) NOT NULL
);
GO

CREATE TABLE [Books]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Title] NVARCHAR(100) NOT NULL,
    [YearPublished] INT NOT NULL,
    [ISBN] NVARCHAR(13) NOT NULL UNIQUE,
    [AuthorId] INT FOREIGN KEY REFERENCES [Authors](Id) NOT NULL,
    [GenreId] INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL
);
GO

CREATE TABLE [Libraries]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [ContactId] INT FOREIGN KEY REFERENCES [Contacts](Id) NOT NULL
);
GO

CREATE TABLE [LibrariesBooks]
(
    [LibraryId] INT FOREIGN KEY REFERENCES [Libraries](Id),
    [BookId] INT FOREIGN KEY REFERENCES [Books](Id),
    PRIMARY KEY([LibraryId], [BookId])
);
GO

-- Section 2. DML
-- using DataSet.sql

-- 2. Insert
INSERT INTO [Contacts]
    ([Email], [PhoneNumber], [PostAddress], [Website])
VALUES
    (NULL, NULL, NULL, NULL),
    (NULL, NULL, NULL, NULL),
    ('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
    ('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com');
GO

INSERT INTO [Authors]
    ([Name], [ContactId])
VALUES
    ('George Orwell', 21),
    ('Aldous Huxley', 22),
    ('Stephen King', 23),
    ('Suzanne Collins', 24);
GO

INSERT INTO Books
    ([Title], [YearPublished], [ISBN], [AuthorId], [GenreId])
VALUES
    ('1984', 1949, '9780451524935', 16, 2),
    ('Animal Farm', 1945, '9780451526342', 16, 2),
    ('Brave New World', 1932, '9780060850524', 17, 2),
    ('The Doors of Perception', 1954, '9780060850531', 17, 2),
    ('The Shining', 1977, '9780307743657', 18, 9),
    ('It', 1986, '9781501142970', 18, 9),
    ('The Hunger Games', 2008, '9780439023481', 19, 7),
    ('Catching Fire', 2009, '9780439023498', 19, 7),
    ('Mockingjay', 2010, '9780439023511', 19, 7);
GO

INSERT INTO LibrariesBooks
    ([LibraryId], [BookId])
VALUES
    (1, 36),
    (1, 37),
    (2, 38),
    (2, 39),
    (3, 40),
    (3, 41),
    (4, 42),
    (4, 43),
    (5, 44);
GO

-- 3. Update
UPDATE [Contacts]
SET [Website] = 'www.' + LOWER(REPLACE([a].[Name], ' ', '')) + '.com'
FROM [Contacts] AS [c]
    JOIN [Authors] AS [a] ON [a].[ContactId] = [c].[Id]
WHERE [c].[Website] IS NULL;
GO

-- 4. Delete
DELETE [lb] FROM [LibrariesBooks] AS [lb]
    JOIN [Books] AS [b] ON [b].[Id] = [lb].[BookId]
    JOIN [Authors] AS [a] ON [a].[Id] = [b].[AuthorId]
WHERE [a].[Name] = 'Alex Michaelides';
GO

DELETE [b] FROM [Books] AS [b]
    JOIN Authors [a] ON [b].[AuthorId] = [a].[Id]
WHERE [a].[Name] = 'Alex Michaelides';
GO

DELETE FROM [Authors]
WHERE [Name] = 'Alex Michaelides';
GO

-- Section 3. Querying
-- 5. Books by Year of Publication
SELECT
    [Title] AS [Book Title],
    [ISBN],
    [YearPublished] AS [YearReleased]
FROM [Books]
ORDER BY [YearPublished] DESC, [Title];
GO

-- 6. Books by Genre
SELECT
    [b].[Id],
    [b].[Title],
    [b].[ISBN],
    [g].[Name] AS [Genre]
FROM [Books] AS [b]
    JOIN [Genres] AS [g] ON [g].[Id] = [b].[GenreId]
WHERE [g].[Name] IN ('Biography', 'Historical Fiction')
ORDER BY [g].[Name], [Title];
GO

-- 7. Libraries Missing Specific Genre
SELECT
    [l].[Name] AS [Library],
    [c].[Email]
FROM [Libraries] AS [l]
    JOIN [Contacts] AS [c] ON [c].[Id] = [l].[ContactId]
WHERE [l].[Id] NOT IN (
    SELECT [lb].[LibraryId]
    FROM [LibrariesBooks] AS [lb]
        JOIN [Books] AS [b] ON [lb].[BookId] = [b].[Id]
        JOIN [Genres] AS [g] ON [b].[GenreId] = [g].[Id]
    WHERE [g].[Name] = 'Mystery'
)
ORDER BY [l].[Name];
GO

-- 8. First 3 Books
SELECT TOP(3)
    [b].[Title],
    [b].[YearPublished] AS [Year],
    [g].[Name] AS [Genre]
FROM [Books] AS [b]
    JOIN [Genres] AS [g] ON [g].[Id] = [b].[GenreId]
WHERE ([b].[YearPublished] > 2000 AND [b].[Title] LIKE '%a%') 
    OR ([b].[YearPublished] < 1950 AND [g].[Name] = 'Fantasy')
ORDER BY [b].[Title], [b].[YearPublished] DESC;
GO

-- 9. Authors from the UK
SELECT 
    [a].[Name] AS [Author],
    [c].[Email],
    [c].[PostAddress] AS [Address]
FROM [Authors] AS [a]
    JOIN [Contacts] as [c] ON [c].[Id] = [a].[ContactId]
WHERE [c].[PostAddress] LIKE '%UK%'
ORDER BY [a].[Name];
GO

-- 10. Fictions in Denver
SELECT
    [a].[Name] AS [Author],
    [b].[Title],
    [l].[Name] AS [Library],
    [c].[PostAddress] AS [Library Address]
FROM [LibrariesBooks] AS [lb]
    JOIN [Libraries] AS [l] ON [l].[Id] = [lb].[LibraryId]
    JOIN [Contacts] AS [c] ON [c].[Id] = [l].[ContactId]
    JOIN [Books] AS [b] ON [b].[Id] = [lb].[BookId]
    JOIN [Authors] AS [a] ON [a].[Id] = [b].[AuthorId]
    JOIN [Genres] AS [g] ON [g].[Id] = [b].[GenreId]
WHERE [g].[Name] = 'Fiction' 
    AND [c].[PostAddress] LIKE '%Denver%'
ORDER BY [b].[Title];
GO

-- Section 4. Programmability
-- 11. Authors with Books
CREATE FUNCTION [udf_AuthorsWithBooks]
    (@name NVARCHAR(100)) 
RETURNS INT
AS
BEGIN
    RETURN 
    (
        SELECT 
            COUNT([lb].[BookId])
        FROM [Authors] AS [a]
            JOIN [Books] AS [b] ON [a].[Id] = [b].[AuthorId]
            JOIN [LibrariesBooks] AS [lb] ON [b].[Id] = [lb].[BookId]
        WHERE [a].[Name] = @name
    );
END;
GO

SELECT [dbo].[udf_AuthorsWithBooks]('J.K. Rowling') AS [Author's books];
GO

-- 12. Search for Books from a Specific Genre (optional City filter)
CREATE PROCEDURE [usp_SearchBookByGenre]
    (@genreName NVARCHAR(30),
    @city NVARCHAR(100) = NULL)
AS
BEGIN
    SELECT 
        [b].[Title],
        [b].[YearPublished] AS [Year],
        [b].[ISBN],
        [a].[Name] AS [Author],
        [g].[Name] As [Genre]
    FROM [Books] AS [b]
        JOIN [Genres] AS [g] ON [g].[Id] = [b].[GenreId]
        JOIN [Authors] AS [a] ON [a].[Id] = [b].[AuthorId]
        LEFT JOIN [LibrariesBooks] AS [lb] ON [lb].[BookId] = [b].[Id]
        LEFT JOIN [Libraries] AS [l] ON [l].[Id] = [lb].[LibraryId]
        LEFT JOIN [Contacts] AS [c] ON [c].[Id] = [l].[ContactId]
    WHERE [g].[Name] = @genreName
        AND (@city IS NULL OR [c].[PostAddress] LIKE '%' + @city + '%')
    ORDER BY [b].[Title], [b].[YearPublished] DESC;
END;
GO