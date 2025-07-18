--Question1
--Design the database for a shop which sells products
--Points for consideration
--  1) One product can be supplied by many suppliers
--  2) One supplier can supply many products
--  3) All customers details have to present
--  4) A customer can buy more than one product in every purchase
--  5) Bill for every purchase has to be stored
--  6) These are just details of one shop

--Note:- you do not have to store the shop details.
use master
go

create database dbShop18Jul2025
Go

use dbShop18Jul2025
Go

create table StatusMaster
(status_id int identity(1,1) constraint pk_StatusId primary key,
Status_Name varchar(50))
GO

create table CategoryMaster
(catrgory_id int identity(1,1) constraint pk_CategoryId primary key,
Category_name nvarchar(50) not null,
status int constraint fk_category_status foreign key references StatusMaster(status_id))
Go

create table OrderStatusMaster
(status_id int identity(1,1) constraint pk_StatusId primary key,
Status_Name varchar(50),
status int constraint fk_OrderStatus_status foreign key references StatusMaster(status_id))
GO

create table ProductStatusMaster
(status_id int identity(1,1) constraint pk_StatusId primary key,
Status_Name varchar(50),
status int constraint fk_ProductStatus_status foreign key references StatusMaster(status_id))
GO

create table SupplyStatusMaster
(status_id int identity(1,1) constraint pk_StatusId primary key,
Status_Name varchar(50),
status int constraint fk_SupplyStatus_status foreign key references StatusMaster(status_id))
GO

create table PeopleStatusMaster
(status_id int identity(1,1) constraint pk_StatusId primary key,
Status_Name varchar(50),
status int constraint fk_PeopleStatus_status foreign key references StatusMaster(status_id))
GO

create table CountryMaster
(country_id int identity(1,1) constraint pk_Country_id primary key,
Country_name nvarchar(20)not null constraint unq_Country unique,
status int constraint fk_Country_status foreign key references StatusMaster(status_id))
Go

create table StateMaster
(State_id int identity(1,1) constraint pk_State_id primary key,
State_name nvarchar(50),
country_id int constraint fk_country_id  foreign key references CountryMaster(country_id),
status int constraint fk_State_status foreign key references StatusMaster(status_id))
Go

create table CityMaster
(City_id int identity(1,1) constraint pk_City_id primary key,
City_name nvarchar(50),
State_id int constraint fk_state_id  foreign key references StateMaster(State_id),
status int constraint fk_City_status foreign key references StatusMaster(status_id))
Go

create table Address
(address_id int identity(1,1) constraint pk_Address_id primary key,
Door_Number varchar(50),
Street_Name varchar(100),
Building_Name varchar(100),
City_id int constraint fk_city_id  foreign key references CityMaster(City_id ),
ZipCode varchar(10) not  null,
status int constraint fk_Address_status foreign key references StatusMaster(status_id))
Go

Create table Suppliers
(supplier_id char(4) constraint pk_Supplier primary key,
supplier_name varchar(100) not null,
contact_person varchar(100) not null,
Phone_number varchar(15) not null,
Email varchar(100) not null,
Address_id int constraint fk_Address_supplier_id  foreign key references Address(address_id),
Supplier_status int constraint fk_supplier_Status  foreign key references PeopleStatusMaster(Status_id))
Go

create table Products
(product_id int identity(1,1) constraint pk_Product primary key,
title varchar(100) not null,
Unit_price float constraint chk_Product_Price check(Unit_price>=0) default 0,
description text,
thumbnail_image varchar(max),
quantity int  constraint chk_Product_Quantity check(quantity>=0) default 0,
Product_Status int constraint fk_Order_Status  foreign key references ProductStatusMaster(Status_id))
Go

Create table ProductImage
(sino int identity(1,1) constraint pk_Product_img primary key,
product_id int constraint fk_Product_Image_id  foreign key references Products(product_id),
image_url varchar(max),
status int constraint fk_ProductImage_status foreign key references StatusMaster(status_id))
Go

create table ProductSupply
(SupplyNumber int identity(1,1) constraint pk_Supply_Number primary key,
product_id int constraint fk_Product_Image_id  foreign key references Products(product_id),
supplier_id char(4) constraint fk_Product_Supplier_id  foreign key references Suppliers(supplier_id),
Supply_Date datetime default GetDate(),
Quantity_Supplied int  constraint chk_Product_Quantity check(Quantity_Supplied >=0) default 0,
product_Supply_status int constraint fk_supply_Status  foreign key references SupplyStatusMaster(Status_id))
Go


Create table Customers
(Customer_id int identity(1,1) constraint pk_Customer primary key,
Customer_name varchar(100) not null,
Phone_number varchar(15) not null,
Email varchar(100) not null,
Address_id int constraint fk_Address_Customer_id  foreign key references Address(address_id),
Customer_status int constraint fk_customer_Status  foreign key references PeopleStatusMaster(Status_id))
Go

create table Orders
(order_number int identity(1,1) constraint pk_Order_number primary key,
Order_Date datetime default GetDate(),
Customer_id int constraint fk_Order_Customer_id  foreign key references Customers(Customer_id),
order_status int constraint fk_Order_Status  foreign key references OrderStatusMaster(Status_id))
Go

create table OrderDetails
(sino int identity(1,1) constraint pk_OrderDetails_number primary key,
order_number int constraint fk_Order_Details foreign key references orders(order_number),
Products_id int constraint fk_Product_Image_id  foreign key references Products(product_id),
quantity int constraint chk_Product_Quantity check(quantity>=1) default 1,
price float constraint chk_Product_Price check(price>=0) default 0,
constraint uq_Product_Order unique(order_number,products_id))
go

