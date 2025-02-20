create database EMedicine;

use EMedicine;

create table Medicines(
ID int identity(1,1) primary key,
Name varchar(100),
Manufacturer varchar(100),
UnitPrice decimal(18,2),
Discount decimal(18,2),
Quantity int,
ExpiryDate datetime,
ImageUrl varchar(200),
Status int
);

select * from Medicines;

create table Users(
ID int identity(1,1) primary key,
FirstName varchar(100),
LastName varchar(100),
Password varchar(100),
Email varchar(100),
Phone varchar(100),
Fund decimal(18,2),
Type varchar(100),
Status int,
CreatedOn datetime
);

select * from Users;

create table Cart(
ID int identity(1,1) primary key,
UserId int,
MedicineId int,
UnitPrice decimal(18,2),
Discount decimal(18,2),
Quantity int,
TotalPrice decimal(18,2)
);

select * from Cart;

create table Orders(
ID int identity(1,1) primary key,
UserId int,
OrderNo varchar(100),
OrderTotal decimal(18,2),
OrderStatus varchar(100)
);

select * from Orders;

create table OrderItems(
ID int identity(1,1) primary key,
OrderId int,
MedicineId int,
UnitPrice decimal(18,2),
Discount decimal(18,2),
Quantity int,
TotalPrice decimal(18,2)
);

select * from OrderItems;
