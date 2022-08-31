USE [library-mgmt-system];
GO

DROP TABLE IF EXISTS [dbo].[author];
DROP TABLE IF EXISTS [dbo].[book];
DROP TABLE IF EXISTS [dbo].[book_author];
DROP TABLE IF EXISTS [dbo].[category];
DROP TABLE IF EXISTS [dbo].[fine];
DROP TABLE IF EXISTS [dbo].[fine_payment];
DROP TABLE IF EXISTS [dbo].[loan];
DROP TABLE IF EXISTS [dbo].[member];
DROP TABLE IF EXISTS [dbo].[member_status];
DROP TABLE IF EXISTS [dbo].[reservation];
DROP TABLE IF EXISTS [dbo].[reservation_status];
GO

CREATE TABLE author (
	AuthorID INT PRIMARY KEY NOT NULL,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL
);

CREATE TABLE book (
	BookID INT PRIMARY KEY NOT NULL,
	Title VARCHAR(50) NOT NULL,
	CategoryID INT,
	PublicationDate DATETIME,
	CopiesOwned INT NOT NULL,
);

CREATE TABLE book_author (
	BookID INT NOT NULL,
	AuthorID INT NOT NULL
);

CREATE TABLE category (
	CategoryID INT PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(50) NOT NULL
);