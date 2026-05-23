CREATE DATABASE Minions;
USE Minions;

CREATE TABLE Minions
(
    Id INT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Age INT
);

CREATE TABLE Towns
(
    Id INT PRIMARY KEY,
    Name VARCHAR(255)
);

ALTER TABLE Minions
ADD TownId INT;

ALTER TABLE Minions
ADD CONSTRAINT FK_TownId
FOREIGN KEY (TownId)
REFERENCES Towns (Id);

SELECT *
FROM Minions;

INSERT INTO Towns
    (Id, Name)
VALUES
    (1, 'Sofia'),
    (2, 'Plovdiv'),
    (3, 'Varna');

INSERT INTO Minions
    (Id, Name, Age, TownId)
VALUES
    (1, 'Kevin', 22, 1),
    (2, 'Bob', 15, 3),
    (3, 'Steward', NULL, 2)

TRUNCATE TABLE Minions;
TRUNCATE TABLE Towns;

DROP TABLE Minions;
DROP TABLE Towns;