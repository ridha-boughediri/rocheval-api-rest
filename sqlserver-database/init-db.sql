CREATE DATABASE rocheval;
GO

USE rocheval;
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    Password NVARCHAR(100)
);
GO
