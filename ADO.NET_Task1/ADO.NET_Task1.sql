CREATE DATABASE ProductManagementDB
USE ProductManagementDB

CREATE TABLE Products
(
 Id int primary key identity,
 [Name] nvarchar(50),
 Price decimal(18,2)
)
CREATE TABLE Categories
(
 Id int primary key identity,
 [Name] nvarchar(50),
)

CREATE TABLE ProductCategory
(
 Id int primary key identity,
 ProductId int FOREIGN KEY REFERENCES Products(Id),
 CategoryId int FOREIGN KEY REFERENCES Categories(Id)
)
CREATE TABLE ProductDetails
(
Id int primary key identity,
Quantity nvarchar(50),
ProductLink nvarchar(50),
ProductId int FOREIGN KEY REFERENCES Products(Id)
)