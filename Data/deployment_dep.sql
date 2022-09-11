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
	AuthorID INT IDENTITY(1, 1) PRIMARY KEY,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL
);

CREATE TABLE category (
	CategoryID INT IDENTITY(1, 1) PRIMARY KEY,
	CategoryName VARCHAR(50) NOT NULL
);

CREATE TABLE book (
	BookID INT IDENTITY(1, 1) PRIMARY KEY,
	Title VARCHAR(50) NOT NULL,
	PublicationDate DATETIME,
	CopiesOwned INT NOT NULL,
	CategoryID INT FOREIGN KEY REFERENCES category(CategoryID),
);

CREATE TABLE book_author (
	BookID INT FOREIGN KEY REFERENCES book(BookID),
	AuthorID INT FOREIGN KEY REFERENCES author(AuthorID)
);

CREATE TABLE member_status (
	MemberStatusID INT IDENTITY(1, 1) PRIMARY KEY,
	StatusValue varchar(50) NOT NULL
);

CREATE TABLE member (
	MemberID INT IDENTITY(1, 1) PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	JoinedDate DATETIME NOT NULL,
	MemberStatusID INT FOREIGN KEY REFERENCES member_status(MemberStatusID)
);

CREATE TABLE fine (
	FineID INT IDENTITY(1, 1) PRIMARY KEY,
	MemberID INT FOREIGN KEY REFERENCES member(MemberID),
	LoanID INT NOT NULL,
	FineDate DATETIME NOT NULL,
	FineAmount DECIMAL(10,2) NOT NULL
);

CREATE TABLE fine_payment (
	FinePaymentID INT IDENTITY(1, 1) PRIMARY KEY,
	MemberID INT FOREIGN KEY REFERENCES member(MemberID),
	PaymentDate DATETIME NOT NULL,
	PaymentAmount DECIMAL(10,2) NOT NULL
);

CREATE TABLE loan (
	LoanID INT IDENTITY(1, 1) PRIMARY KEY,
	BookID INT FOREIGN KEY REFERENCES book(BookID),
	MemberID INT FOREIGN KEY REFERENCES member(MemberID),
	LoanDate DATETIME NOT NULL,
	ReturnedDate DATETIME
);

CREATE TABLE reservation_status (
	ReservationStatusID INT IDENTITY(1, 1) PRIMARY KEY,
	StatusValue varchar(50) NOT NULL
);

CREATE TABLE reservation (
	ReservationID INT IDENTITY(1, 1) PRIMARY KEY,
	BookID INT FOREIGN KEY REFERENCES book(BookID),
	MemberID INT FOREIGN KEY REFERENCES member(MemberID),
	ReservationDate DATETIME NOT NULL,
	ReservationStatusID INT FOREIGN KEY REFERENCES reservation_status(ReservationStatusID)
);
GO