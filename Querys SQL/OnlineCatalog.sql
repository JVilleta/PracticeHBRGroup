CREATE DATABASE OnlineCatalog
GO 
USE OnlineCatalog
GO 

--Tabla Usuarios
create table Users(
Id int identity (1,1) PRIMARY KEY,
UserName varchar(50),
LastName varchar(50),
Telephone varchar(50),
Email varchar(80),
Pass varchar(200),
Status bit,
CreationDate datetime, 
UpdateDate datetime
)


--Tabla categorias
create table Categories(
Id int identity(1,1) PRIMARY KEY,
CategoryCode varchar(50),
CategoryName varchar(50),
Descriptions varchar (100),
Status bit,
Author varchar (100),
CreationDate datetime,
UpdateDate datetime
)

--Tabla productos
create table Products(
Id int identity (1,1) PRIMARY KEY,
ProductCode varchar (50),
ProductName varchar(50),
Stock int,
Status bit,
Author varchar (100),
CreationDate datetime,
UpdateDate datetime,
IdCategory int

CONSTRAINT FK_CATEGORIA FOREIGN KEY (IdCategory) REFERENCES Categories(Id)
ON DELETE CASCADE
ON UPDATE CASCADE
)

