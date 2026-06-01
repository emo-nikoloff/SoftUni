-- Part I.
CREATE DATABASE [TableRelations];
GO

USE [TableRelations];
GO

-- Задача 1
CREATE TABLE [Passports]
(
    [PassportID] INT PRIMARY KEY IDENTITY(101, 1),
    [PassportNumber] CHAR(8) UNIQUE NOT NULL
);
GO

CREATE TABLE [Persons]
(
    [PersonID] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(50) NOT NULL,
    [Salary] DECIMAL(10, 2),
    [PassportID] INT FOREIGN KEY REFERENCES [Passports](PassportID) UNIQUE
);
GO

INSERT INTO [Passports]
    ([PassportNumber])
VALUES
    ('N34FG21B'),
    ('K65LO4R7'),
    ('ZE657QP2');
GO

INSERT INTO [Persons]
    ([FirstName], [Salary], [PassportID])
VALUES
    ('Roberto', 43300.00, 102),
    ('Tom', 56100.00, 103),
    ('Yana', 60200.00, 101);
GO

-- Задача 2
CREATE TABLE [Manufacturers]
(
    [ManufacturerID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    [EstablishedOn] DATE NOT NULL
);
GO

CREATE TABLE [Models]
(
    [ModelID] INT PRIMARY KEY IDENTITY(101, 1),
    [Name] VARCHAR(50) NOT NULL,
    [ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers](ManufacturerID) NOT NULL
);
GO

INSERT INTO [Manufacturers]
    ([Name], [EstablishedOn])
VALUES
    ('BMW', '07/03/1916'),
    ('Tesla', '01/01/2003'),
    ('Lada', '01/05/1966');
GO

INSERT INTO [Models]
    ([Name], [ManufacturerID])
VALUES
    ('X1', 1),
    ('i6', 1),
    ('Model S', 2),
    ('Model X', 2),
    ('Model 3', 2),
    ('Nova', 3);
GO

-- Задача 3
CREATE TABLE [Students]
(
    [StudentID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Exams]
(
    [ExamID] INT PRIMARY KEY IDENTITY(101, 1),
    [Name] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [StudentsExams]
(
    [StudentID] INT FOREIGN KEY REFERENCES [Students](StudentID),
    [ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]),
    PRIMARY KEY([StudentID], [ExamID])
);
GO

INSERT INTO [Students]
    ([Name])
VALUES
    ('Mila'),
    ('Toni'),
    ('Ron');
GO

INSERT INTO [Exams]
    ([Name])
VALUES
    ('SpringMVC'),
    ('Neo4j'),
    ('Oracle 11g');
GO

INSERT INTO [StudentsExams]
    ([StudentID], [ExamID])
VALUES
    (1, 101),
    (1, 102),
    (2, 101),
    (3, 103),
    (2, 102),
    (2, 103);
GO

-- Задача 4
CREATE TABLE [Teachers]
(
    [TeacherID] INT PRIMARY KEY IDENTITY(101, 1),
    [Name] VARCHAR(50) NOT NULL,
    [ManagerID] INT FOREIGN KEY REFERENCES [Teachers](TeacherID)
);
GO

INSERT INTO [Teachers]
    ([Name], [ManagerID])
VALUES
    ('John', NULL),
    ('Maya', 106),
    ('Silvia', 106),
    ('Ted', 105),
    ('Mark', 101),
    ('Greta', 101);
GO

-- Part II.
-- Задача 5
CREATE DATABASE [OnlineStore];
GO

USE [OnlineStore];
GO

CREATE TABLE [Cities]
(
    [CityID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Customers]
(
    [CustomerID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    [Birthday] DATE,
    [CityID] INT FOREIGN KEY REFERENCES [Cities](CityID) NOT NULL
);
GO

CREATE TABLE [Orders]
(
    [OrderID] INT PRIMARY KEY IDENTITY,
    [CustomerID] INT FOREIGN KEY REFERENCES [Customers](CustomerID) NOT NULL,
);
GO

CREATE TABLE [ItemTypes]
(
    [ItemTypeID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Items]
(
    [ItemID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    [ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes](ItemTypeID) NOT NULL
);
GO

CREATE TABLE [OrderItems]
(
    [OrderID] INT FOREIGN KEY REFERENCES [Orders](OrderID),
    [ItemID] INT FOREIGN KEY REFERENCES [Items](ItemID),
    PRIMARY KEY([OrderID], [ItemID])
);
GO

-- Задача 6
CREATE DATABASE [University];
GO

USE [University];
GO

CREATE TABLE [Majors]
(
    [MajorID] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Subjects]
(
    [SubjectID] INT PRIMARY KEY IDENTITY,
    [SubjectName] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Students]
(
    [StudentID] INT PRIMARY KEY IDENTITY,
    [StudentNumber] CHAR(9) NOT NULL,
    [StudentName] VARCHAR(50) NOT NULL,
    [MajorID] INT FOREIGN KEY REFERENCES [Majors](MajorID) NOT NULL
);
GO

CREATE TABLE [Payments]
(
    [PaymentID] INT PRIMARY KEY IDENTITY,
    [PaymentDate] DATE NOT NULL,
    [PaymentAmount] DECIMAL(10 ,2) NOT NULL,
    [StudentID] INT FOREIGN KEY REFERENCES [Students](StudentID) NOT NULL
);
GO

CREATE TABLE [Agenda]
(
    [StudentID] INT FOREIGN KEY REFERENCES [Students](StudentID),
    [SubjectID] INT FOREIGN KEY REFERENCES [Subjects](SubjectID),
    PRIMARY KEY([StudentID], [SubjectID])
);
GO

-- Задача 9
USE [Geography];
GO

SELECT [MountainRange], [PeakName], [Elevation]
FROM [Mountains]
    JOIN [Peaks] ON [Peaks].[MountainId] = [Mountains].[Id]
WHERE [MountainRange] = 'Rila'
ORDER BY [Elevation] DESC;
GO