CREATE DATABASE DataADCBook;
USE DataADCBook;
SELECT * from dbo.Bill;

CREATE TABLE Company (
	idCompany INT PRIMARY KEY IDENTITY,
	nameCompany NVARCHAR(100) NOT NULL,
	addressCompany NVARCHAR(255) NOT NULL,
	phoneNumber NVARCHAR(20) NOT NULL
);

CREATE TABLE Author (
	idAuthor INT PRIMARY KEY IDENTITY,
	nameAuthor NVARCHAR(100) NOT NULL,
	birthYear INT NOT NULL,
	homeTown NVARCHAR(100) NOT NULL
);

CREATE TABLE [Type] (
	idType INT PRIMARY KEY IDENTITY,
	nameType NVARCHAR(100) NOT NULL,
);

CREATE TABLE ExchangeBook (
	idExchangeBook INT PRIMARY KEY IDENTITY,
	idBook INT NOT NULL,
	nameBook NVARCHAR(100) NOT NULL,
	number INT NOT NULL,
	reason NVARCHAR(100) NOT NULL,
	[status] NVARCHAR(100) NOT NULL,
	startDay DATETIME NOT NULL,
	endDay DATETIME
);

CREATE TABLE Book (
	idBook INT PRIMARY KEY IDENTITY,
	nameBook NVARCHAR(100) NOT NULL,
	nameCompany NVARCHAR(100) NOT NULL,
	nameAuthor NVARCHAR(100) NOT NULL,
	nameType NVARCHAR(100) NOT NULL,
	number INT NOT NULL,
	priceI FLOAT NOT NULL,
	priceO FLOAT NOT NULL
);

CREATE TABLE Discount (
	idDiscount INT PRIMARY KEY IDENTITY,
	nameDiscount NVARCHAR(100) NOT NULL,
	StartDiscountDate DATE NOT NULL,
	EndDiscountDate DATE NOT NULL,
	DiscountValue INT NOT NULL
);

CREATE TABLE Custommer (
	idCustommer INT PRIMARY KEY IDENTITY,
	nameCustommer NVARCHAR(100) NOT NULL,
	BirstDay DATE NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	phoneNumber NVARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	CreateAccount DATETIME NOT NULL
);

CREATE TABLE Bill (
	idBill INT PRIMARY KEY IDENTITY,
	nameCustommer NVARCHAR(100),
	DiscountValue INT,
	TotalPriceDiscount FLOAT,
	PayTotal FLOAT,
	[status] NVARCHAR(100),
	CreateDate DATETIME
);

CREATE TABLE BillBook (
	idBill INT,
	idBook INT,
	numberBook INT NOT NULL
);

CREATE TABLE [Order] (
	idOrder INT PRIMARY KEY IDENTITY,
	nameOrder NVARCHAR(100) NOT NULL,
	CreateDateOrder DATETIME NOT NULL,
	BillTotal INT NOT NULL,
	StatusOrder VARCHAR(100) NOT NULL,
	BillDate DATETIME
);

CREATE TABLE Employee(
	idEmployee INT,
	nameEmployee NVARCHAR(100),
	positionEmployee NVARCHAR(100),
	birthDay DATE,
	sex NVARCHAR(100),
	phoneNumber NVARCHAR(100)
)
