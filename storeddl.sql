use master;
go

CREATE DATABASE AstoreApplicationDB;
go

Use AstoreApplicationDB;
go
create schema Store;
go

CREATE SCHEMA Customer;
go

alter table Customer.Customer add Password nvarchar(10);
CREATE TABLE Customer.Customer
(
CustomerId int not null identity(1,1),
FirstName nvarchar(100) not null,
LastName nvarchar(100) not null,
Primary key (CustomerId),
);

select * from Customer.Customer;
CREATE TABLE Store.Store
(
StoreId int not null identity(1,1),
StoreName nvarchar(100) not null,
StoreLocation nvarchar(120) not null,
Primary Key (StoreId),
);
CREATE TABLE Store.Product
(
ProductId int not null identity(1,1),
ProductName nvarchar(100) not null,
ProductDescription nvarchar(300) not null,
ProductPrice money not null,
CONSTRAINT UK_ProductName Unique(ProductName),
Primary Key (ProductId),
);
alter table Store.Product add CONSTRAINT UK_ProductName Unique(ProductName);
select ProductName,ProductId from Store.Product where ProductName ='Isolation';
  alter table Store.Product add ProductPrice money not null;
alter table Store.Product drop column ProductPrict;
alter table Store.[Order] drop column OrderDate;
alter table Store.[Order] add OrderDate DATETIME2 NOT NULL;
create table Store.[Order]
(
    OrderId INT not null identity(1,1),
	CustomerId INT not null,
	StoreId INT not null,
	OrderTotal Money,
	OrderDate DATETIME2 NOT NULL,
Primary Key(OrderId),
);
select * from Store.[Order];
create table Store.OrderProduct
(
    OrderProductId INT not null identity(1,1),
	OrderId INT not null,
	ProductId INT not null,
	Quantity int not null,
	Primary Key(OrderProductId),
);


CREATE TABLE Store.Inventory
(
	InventoryId INT IDENTITY(1,1),
	StoreId INT NOT NULL,
	ProductId INT NOT NULL,
	Quantity int not null,
	Primary Key(InventoryId),
);
GO
ALTER TABLE Store.Inventory add Quantity int not null; 

select * from Store.Inventory ;

--add reference 
--connect order with customer
ALTER TABLE Store.[Order]
	add constraint FK_Order_Customer foreign key (CustomerId) references Customer.Customer(CustomerId);

--connect order with soter	
ALTER TABLE Store.[Order]
	add constraint FK_Order_Store foreign key (StoreId) references Store.Store(StoreId);


--connet inventory with store
ALTER TABLE Store.Inventory
	ADD constraint FK_Iventory_Store Foreign key (StoreId) references Store.Store(StoreId);
--connect inventory with product
Alter TABLE Store.Inventory
	ADD constraint FK_Iventory_Product Foreign key (ProductId) references Store.Product(ProductId);

--connect product with order
Alter table Store.OrderProduct 
	ADD constraint FK_Order_Product Foreign key(ProductId) references Store.Product(ProductId);

Alter table Store.OrderProduct
ADD constraint FK_Order_Order Foreign key (OrderId) references Store.[Order](OrderId);