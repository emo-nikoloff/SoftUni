-- Задача 1
CREATE DATABASE [Minions];
GO

USE [Minions];
GO

-- Задача 2
CREATE TABLE [Minions]
(
    [Id] INT PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Age] INT
);
GO

CREATE TABLE [Towns]
(
    [Id] INT PRIMARY KEY,
    [Name] VARCHAR(80) NOT NULL
);
GO

-- Задача 3
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns](Id);
GO

-- Задача 4
INSERT INTO [Towns]
    ([Id], [Name])
VALUES
    (1, 'Sofia'),
    (2, 'Plovdiv'),
    (3, 'Varna');
GO

INSERT INTO [Minions]
    ([Id], [Name], [Age], [TownId])
VALUES
    (1, 'Kevin', 22, 1),
    (2, 'Bob', 15, 3),
    (3, 'Steward', NULL, 2);
GO

-- Задача 5
-- I. Using TRUNCATE
TRUNCATE TABLE [Minions];

-- II. Using DELETE
DELETE FROM [Minions];

GO

-- Задача 6
DROP TABLE [Minions];
GO

DROP TABLE [Towns];
GO

-- Задача 7
CREATE TABLE [People]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL,
    [Picture] VARBINARY(MAX) CHECK(LEN([Picture]) <= 2097152),
    [Height] DECIMAL(5, 2),
    [Weight] DECIMAL(5, 2),
    [Gender] CHAR(1) NOT NULL CHECK([Gender] IN ('m', 'f')),
    -- Другият вариант е с релация към таблица [Genders]
    [Birthdate] DATE NOT NULL,
    [Biography] NVARCHAR(MAX)
);
GO

INSERT INTO People
    ([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES
    ('Ivan Ivanov', NULL, 1.85, 80.50, 'm', '1990-05-15', 'Ivan is a software engineer.'),
    ('Mariya Petrova', NULL, 1.65, 55.00, 'f', '1995-10-22', 'Mariya loves to read books and travel.'),
    ('Georgi Dimitrov', NULL, 1.78, 75.30, 'm', '1988-03-10', NULL),
    ('Elena Nikolova', NULL, 1.70, 62.10, 'f', '2000-12-05', 'Computers Science student.'),
    ('Petar Stoyanov', NULL, 1.90, 95.00, 'm', '1985-07-30', 'Petar plays basketball in his free time.');
GO

-- Задача 8
CREATE TABLE [Users]
(
    [Id] BIGINT PRIMARY KEY IDENTITY,
    [Username] VARCHAR(30) UNIQUE NOT NULL,
    [Password] VARCHAR(26) NOT NULL,
    [ProfilePicture] VARBINARY(MAX) CHECK(LEN([ProfilePicture]) <= 921600),
    [LastLoginTime] DATETIME2,
    [IsDeleted] BIT NOT NULL
);
GO

INSERT INTO [Users]
    ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
    ('ivan_88', 'secretPass123!', NULL, '2023-10-15 14:30:00', 0),
    ('maria_bg', 'qwerty123456', NULL, '2023-10-16 09:15:00', 1),
    ('georgi_dev', 'gogo_strong_pass', NULL, '2023-10-17 18:45:00', 0),
    ('elena_cool', 'pass1234', NULL, '2023-10-18 10:00:00', 0),
    ('peter_pan', 'neverland2023', NULL, '2023-10-19 22:10:00', 1);
GO

-- Задача 9
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__77222459DF638B07];
GO

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Users_Id_Username] PRIMARY KEY([Id], [Username]);
GO

-- Задача 10
ALTER TABLE [Users]
ADD CONSTRAINT [CK_Users_Password_Min_Length_5] CHECK(LEN([Password]) >= 5);
GO

-- Задача 11
ALTER TABLE [Users]
ADD CONSTRAINT [DF_Users_LastLoginTime] DEFAULT(GETDATE()) FOR [LastLoginTime];
GO

-- Задача 12
ALTER TABLE [Users]
DROP CONSTRAINT [UQ__Users__536C85E41A4862CC];
GO

ALTER TABLE [Users]
DROP CONSTRAINT [PK_Users_Id_Username];
GO

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Users_Id] PRIMARY KEY([Id]);
GO

ALTER TABLE [Users]
ADD CONSTRAINT [UQ_Users_Username] UNIQUE([Username])
GO

ALTER TABLE [Users]
ADD CONSTRAINT [CK_Users_Username_Min_Length_3] CHECK(LEN([Username]) >= 3);
GO

-- Задача 13
CREATE DATABASE [Movies];
GO

USE [Movies];
GO

CREATE TABLE [Directors]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [DirectorName] VARCHAR(100) NOT NULL,
    [Notes] VARCHAR(MAX)
);
GO

CREATE TABLE [Genres]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [GenreName] VARCHAR(100) NOT NULL,
    [Notes] VARCHAR(MAX)
);
GO

CREATE TABLE [Categories]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [CategoryName] VARCHAR(100) NOT NULL,
    [Notes] VARCHAR(MAX)
);
GO

CREATE TABLE [Movies]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Title] VARCHAR(200) NOT NULL,
    [DirectorId] INT FOREIGN KEY REFERENCES [Directors](Id) NOT NULL,
    [CopyrightYear] DATE NOT NULL,
    [Length] INT NOT NULL,
    [GenreId] INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL,
    [CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
    [Rating] TINYINT,
    [Notes] VARCHAR(MAX)
);
GO

INSERT INTO [Directors]
    ([DirectorName], [Notes])
VALUES
    ('Steven Spielberg', 'Known for blockbusters like Jurassic Park.'),
    ('Christopher Nolan', 'Known for complex narratives like Inception.'),
    ('Quentin Tarantino', 'Distinctive dialogue and nonlinear storylines.'),
    ('James Cameron', 'Director of Titanic and Avatar.'),
    ('Martin Scorsese', NULL);
GO

INSERT INTO [Genres]
    ([GenreName], [Notes])
VALUES
    ('Action', 'High energy, physical stunts and chases.'),
    ('Comedy', 'Intended to make the audience laugh.'),
    ('Drama', 'Focuses on emotional themes and character development.'),
    ('Sci-Fi', 'Explores futuristic concepts and advanced technology.'),
    ('Thriller', NULL);
GO

INSERT INTO [Categories]
    ([CategoryName], [Notes])
VALUES
    ('Feature Film', 'Standard full-length movie.'),
    ('Short Film', 'A motion picture not long enough to be considered a feature film.'),
    ('Documentary', 'Non-fictional motion picture intended to document reality.'),
    ('Animation', 'Created using computer graphics or hand-drawn animation.'),
    ('Miniseries', NULL);
GO

INSERT INTO [Movies]
    ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES
    ('Jurassic Park', 1, '1993-06-11', 127, 1, 1, 9, 'Classic dinosaur blockbuster.'),
    ('Inception', 2, '2010-07-16', 148, 4, 1, 9, 'A thief who steals corporate secrets through the use of dream-sharing technology.'),
    ('Pulp Fiction', 3, '1994-10-14', 154, 5, 1, 10, NULL),
    ('Avatar', 4, '2009-12-18', 162, 4, 1, 8, 'Set in the mid-22nd century on Pandora.'),
    ('Goodfellas', 5, '1990-09-19', 146, 3, 1, 9, 'The story of Henry Hill and his life in the mob.');
GO

-- Задача 14
CREATE DATABASE [CarRental];
GO

USE [CarRental];
GO

CREATE TABLE [Categories]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [CategoryName] VARCHAR(50) NOT NULL,
    [DailyRate] DECIMAL (10, 2),
    [WeeklyRate] DECIMAL (10, 2),
    [MonthlyRate] DECIMAL (10, 2),
    [WeekendRate] DECIMAL (10, 2)
);
GO

CREATE TABLE [Cars]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [PlateNumber] CHAR(8) NOT NULL,
    [Manufacturer] VARCHAR(50) NOT NULL,
    [Model] VARCHAR(20) NOT NULL,
    [CarYear] INT NOT NULL,
    [CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id),
    [Doors] TINYINT NOT NULL,
    [Picture] VARBINARY(MAX),
    [Condition] VARCHAR(20) NOT NULL,
    [Available] BIT NOT NULL
);
GO

CREATE TABLE [Employees]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [Title] VARCHAR(20) NOT NULL,
    [Notes] VARCHAR(MAX)
);
GO

CREATE TABLE [Customers]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [DriverLicenseNumber] VARCHAR(16) NOT NULL,
    [FullName] VARCHAR(100) NOT NULL,
    [Address] VARCHAR(50),
    [City] VARCHAR(50) NOT NULL,
    [ZIPCode] CHAR(5) NOT NULL,
    [Notes] VARCHAR(MAX)
);
GO

CREATE TABLE [RentalOrders]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id),
    [CustomerId] INT FOREIGN KEY REFERENCES [Customers](Id),
    [CarId] INT FOREIGN KEY REFERENCES [Cars] (Id),
    [TankLevel] DECIMAL(5,2) NOT NULL,
    [KilometrageStart] INT NOT NULL,
    [KilometrageEnd] INT,
    [TotalKilometrage] INT,
    [StartDate] DATETIME2 NOT NULL,
    [EndDate] DATETIME2,
    [TotalDays] INT,
    [RateApplied] DECIMAL(10, 2) NOT NULL,
    [TaxRate] DECIMAL(10, 2) NOT NULL,
    [OrderStatus] BIT NOT NULL,
    [Notes] VARCHAR(MAX)
);
GO

INSERT INTO [Categories]
    ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
    ('Economy', 30.00, 150.00, 500.00, 40.00),
    ('Luxury', 150.00, 800.00, 2500.00, 200.00),
    ('SUV', 80.00, 400.00, 1200.00, 100.00);
GO

INSERT INTO [Employees]
    ([FirstName], [LastName], [Title], [Notes])
VALUES
    ('John', 'Doe', 'Manager', 'Very experienced'),
    ('Jane', 'Smith', 'Sales Rep', NULL),
    ('Mike', 'Johnson', 'Mechanic', 'Checks cars before rent');
GO

INSERT INTO [Customers]
    ([DriverLicenseNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
VALUES
    ('DL12345678', 'Alice Brown', '123 Main St', 'Sofia', '1000', 'Regular customer'),
    ('DL87654321', 'Bob White', '456 Oak Ave', 'Plovdiv', '4000', NULL),
    ('DL11223344', 'Charlie Green', '789 Pine Rd', 'Varna', '9000', 'Prefers SUVs');
GO

INSERT INTO [Cars]
    ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
VALUES
    ('CB1234AB', 'Toyota', 'Yaris', 2018, 1, 4, NULL, 'Excellent', 1),
    ('CB5678CD', 'Mercedes', 'S-Class', 2022, 2, 4, NULL, 'Like New', 0),
    ('PB9876EF', 'Honda', 'CR-V', 2015, 3, 5, NULL, 'Good', 1);
GO

INSERT INTO [RentalOrders]
    ([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays],
    [RateApplied], [TaxRate], [OrderStatus], [Notes])
VALUES
    (1, 1, 2, 65.50, 15000, NULL, NULL, '2023-10-25 10:00:00', NULL, NULL, 150.00, 20.00, 0, 'Rented the Mercedes for a week'),
    (2, 2, 1, 40.00, 85000, 85300, 300, '2023-09-10 09:30:00', '2023-09-15 14:00:00', 5, 30.00, 20.00, 1, 'Completed without issues'),
    (1, 3, 3, 55.00, 120000, 120500, 500, '2023-08-11 16:00:00', '2023-08-14 09:00:00', 3, 40.00, 20.00, 1, 'Used the weekend rate');
GO

-- Задача 15
CREATE DATABASE [Hotel];
GO

USE [Hotel];
GO

CREATE TABLE [Employees]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [Title] VARCHAR(20) NOT NULL,
    [Notes] VARCHAR(MAX)
);
GO

CREATE TABLE [Customers]
(
    [AccountNumber] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [PhoneNumber] VARCHAR(20) NOT NULL,
    [EmergencyName] VARCHAR(100),
    [EmergencyNumber] VARCHAR(20),
    [Notes] VARCHAR(MAX)
);
GO

CREATE TABLE [RoomStatuses]
(
    [RoomStatus] VARCHAR(50) PRIMARY KEY,
    [Notes] VARCHAR(MAX)
);
GO

CREATE TABLE [RoomTypes]
(
    [RoomType] VARCHAR(50) PRIMARY KEY,
    [Notes] VARCHAR (MAX)
);
GO

CREATE TABLE [BedTypes]
(
    [BedType] VARCHAR(50) PRIMARY KEY,
    [Notes] VARCHAR (MAX)
);
GO

CREATE TABLE [Rooms]
(
    [RoomNumber] SMALLINT PRIMARY KEY,
    [RoomType] VARCHAR(50) FOREIGN KEY REFERENCES [RoomTypes](RoomType) NOT NULL,
    [BedType] VARCHAR(50) FOREIGN KEY REFERENCES [BedTypes](BedType) NOT NULL,
    [Rate] DECIMAL(10, 2) NOT NULL,
    [RoomStatus] VARCHAR(50) FOREIGN KEY REFERENCES [RoomStatuses](RoomStatus) NOT NULL,
    [Notes] VARCHAR(MAX)
);
GO

CREATE TABLE [Payments]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id),
    [PaymentDate] DATETIME2 NOT NULL,
    [AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
    [FirstDateOccupied] DATE NOT NULL,
    [LastDateOccupied] DATE NOT NULL,
    [TotalDays] INT NOT NULL,
    [AmountCharged] DECIMAL(10, 2) NOT NULL,
    [TaxRate] DECIMAL(10, 2) NOT NULL,
    [TaxAmount] DECIMAL(10, 2) NOT NULL,
    [PaymentTotal] DECIMAL(10, 2) NOT NULL,
    [Notes] VARCHAR(MAX)
);
GO

CREATE TABLE [Occupancies]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
    [DateOccupied] DATE NOT NULL,
    [AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
    [RoomNumber] SMALLINT FOREIGN KEY REFERENCES [Rooms](RoomNumber) NOT NULL,
    [RateApplied] DECIMAL(10, 2) NOT NULL,
    [PhoneCharge] DECIMAL(10, 2),
    [Notes] VARCHAR(MAX)
);
GO

INSERT INTO [RoomStatuses]
    ([RoomStatus], [Notes])
VALUES
    ('Available', 'Room is clean and ready for guests.'),
    ('Occupied', 'Guests are currently staying in the room.'),
    ('Cleaning', 'Guests checked out, room is being cleaned.');
GO

INSERT INTO [RoomTypes]
    ([RoomType], [Notes])
VALUES
    ('Single', 'Room with one single bed.'),
    ('Double', 'Room with two single beds or one double bed.'),
    ('Suite', 'Luxury apartment with living area.');
GO

INSERT INTO [BedTypes]
    ([BedType], [Notes])
VALUES
    ('Single', 'Standard single bed.'),
    ('Double', 'Standard double bed.'),
    ('King Size', 'Extra large king size bed.');
GO

INSERT INTO [Employees]
    ([FirstName], [LastName], [Title], [Notes])
VALUES
    ('Ivan', 'Ivanov', 'Receptionist', 'Works day shifts.'),
    ('Maria', 'Petrova', 'Hotel Manager', 'Oversees all operations.'),
    ('Georgi', 'Todorov', 'Bellhop', NULL);
GO

INSERT INTO [Customers]
    ([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes])
VALUES
    ('Peter', 'Filipov', '0888111222', 'Elena Filipova', '0888333444', 'VIP Customer'),
    ('Anna', 'Dimova', '0899555666', 'Stefan Dimov', '0899777888', NULL),
    ('Vasil', 'Kolev', '0877999000', 'Radka Koleva', '0877111222', 'Prefers quiet rooms');
GO

INSERT INTO [Rooms]
    ([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus], [Notes])
VALUES
    (101, 'Single', 'Single', 50.00, 'Available', 'First floor, street view.'),
    (102, 'Double', 'Double', 80.00, 'Occupied', 'First floor, quiet side.'),
    (201, 'Suite', 'King Size', 150.00, 'Cleaning', 'Second floor, sea view.');
GO

INSERT INTO [Payments]
    ([EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [TotalDays], [AmountCharged], [TaxRate], [TaxAmount], [PaymentTotal], [Notes])
VALUES
    (1, '2026-05-10 14:00:00', 1, '2026-05-05', '2026-05-10', 5, 250.00, 20.00, 50.00, 300.00, 'Paid in full with credit card.'),
    (2, '2026-05-12 11:30:00', 2, '2026-05-08', '2026-05-12', 4, 320.00, 20.00, 64.00, 384.00, NULL),
    (1, '2026-05-15 09:15:00', 3, '2026-05-10', '2026-05-15', 5, 750.00, 20.00, 150.00, 900.00, 'Company account payment.');
GO

INSERT INTO [Occupancies]
    ([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge], [Notes])
VALUES
    (1, '2026-05-05', 1, 101, 50.00, 5.20, 'Checked in early.'),
    (2, '2026-05-08', 2, 102, 80.00, NULL, 'Requested extra towels.'),
    (3, '2026-05-10', 3, 201, 150.00, 12.50, 'Luggage delivered to room.');
GO

-- Задача 16
CREATE DATABASE [SoftUni];
GO

USE [SoftUni];
GO

CREATE TABLE [Towns]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Addresses]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [AddressText] VARCHAR(50) NOT NULL,
    [TownId] INT FOREIGN KEY REFERENCES [Towns](Id) NOT NULL
);
GO

CREATE TABLE [Departments]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [Employees]
(
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(50) NOT NULL,
    [MiddleName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [JobTitle] VARCHAR(50) NOT NULL,
    [DepartmentId] INT FOREIGN KEY REFERENCES [Departments](Id) NOT NULL,
    [HireDate] DATE NOT NULL,
    [Salary] DECIMAL(10, 2) NOT NULL,
    [AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id)
);
GO

-- Задача 18
INSERT INTO [Towns]
    ([Name])
VALUES
    ('Sofia'),
    ('Plovdiv'),
    ('Varna'),
    ('Burgas');
GO

INSERT INTO [Departments]
    ([Name])
VALUES
    ('Engineering'),
    ('Sales'),
    ('Marketing'),
    ('Software Development'),
    ('Quality Assurance');
GO

INSERT INTO [Employees]
    ([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
VALUES
    ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
    ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
    ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
    ('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
    ('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88);
GO

-- Задача 19
SELECT *
FROM [Towns];
GO

SELECT *
FROM [Departments];
GO

SELECT *
FROM [Employees];
GO

-- Задача 20
SELECT *
FROM [Towns]
ORDER BY [Name];
GO

SELECT *
FROM [Departments]
ORDER BY [Name];
GO

SELECT *
FROM [Employees]
ORDER BY [Salary] DESC;
GO

-- Задача 21
SELECT [Name]
FROM [Towns]
ORDER BY [Name];
GO

SELECT [Name]
FROM [Departments]
ORDER BY [Name];
GO

SELECT [FirstName], [LastName], [JobTitle], [Salary]
FROM [Employees]
ORDER BY [Salary] DESC;
GO

-- Задача 22
UPDATE [Employees]
SET [Salary] += ([Salary] * 0.1);
GO

SELECT [Salary]
FROM [Employees];
GO

-- Задача 23
USE [Hotel];
GO

UPDATE [Payments]
SET [TaxRate] -= ([TaxRate] * 0.03);
GO

SELECT [TaxRate]
FROM [Payments];
GO

-- Задача 24
TRUNCATE TABLE [Occupancies];
GO