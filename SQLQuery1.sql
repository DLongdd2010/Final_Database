CREATE DATABASE DATABASE_ASM;
GO
USE DATABASE_ASM
GO
CREATE TABLE Category
(
	CategoryID int primary key identity(1,1),
	CategoryName nvarchar(100) not null
);

CREATE TABLE Author
(
	AuthorID int primary key identity(1,1),
	AuthorName nvarchar(100) not null
);
select * from [dbo].[Author]
CREATE TABLE Book
(
	BookID int primary key identity(1,1),
	BookCode nvarchar(50) not null,
	BookName nvarchar(100) not null,
	Price decimal(10,2) not null,
	InventoryQuantity int not null,
	ProductImage nvarchar(max),
	CategoryID int,
	AuthorID int,
	foreign key (CategoryID) references Category(CategoryID),
	foreign key (AuthorID) references Author(AuthorID)
);
insert into [dbo].[Book]
values 
('B1','abc','1','10','x','1','2'),
('B2','qwe','1','10','x','2','1');

select Book.BookID, Author.AuthorName
from Book
inner join Author on Book.BookID = Author.AuthorID;

select * from [dbo].[Book]
CREATE TABLE Employee
(
	EmployeeID int primary key identity(1,1),
	EmployeeCode nvarchar(50) not null,
	EmployeeName nvarchar(100) not null,
	PhoneNumber nvarchar(20),
	Address nvarchar(255),
	Position nvarchar(50),
	AuthorityLevel nvarchar(50),
	Username nvarchar(50) not null unique,
	Password nvarchar(225) not null,
);
alter table [dbo].[Employee]
add PasswordChanged bit default 0;

insert into [dbo].[Employee]
values 
('Emp1','Dao Duy Long','0123','Ha Noi','Admin','Admin','DuyLong1','123',1),
('Emp2','DuyLong1','0123','Ha Noi','Staff','Sale','Long1','123',1),
('Emp3','DuyLong2','0123','Ha Noi','Staff','Warehouse','Long2','123',1);

insert into [dbo].[Employee]
values
('Emp4','DuyLong3','0123','Ha Noi','Staff','Sale','DuyLong3','123',0),
('Emp5','DuyLong4','0123','Ha Noi','Staff','Warehouse','DuyLong4','123',0)

select * from [dbo].[Employee]

CREATE TABLE Customer
(
	CustomerID int primary key identity(1,1),
	Customercode nvarchar(50) not null,
	CustomerName nvarchar(100) not null,
	PhoneNumber nvarchar(20),
	Address nvarchar(255)
);
insert into [dbo].[Customer]
values
('Cus1','DuyLong123','0123','Ha Noi'),
('Cus2','TuanMinh','0123','Quang Ninh');

select * from [dbo].[Customer]
CREATE TABLE Sale
(
	SaleID int primary key identity(1,1),
	SaleDate datetime not null,
	EmployeeID int,
	CustomerID int,
	foreign key (EmployeeID) references Employee(EmployeeID),
	foreign key (CustomerID) references Customer(CustomerID)
);

CREATE TABLE SaleDetail
(
	SaleDetailID int primary key identity(1,1),
	SaleID int,
	BookID int,
	QuantitySold int not null,
	foreign key (SaleID) references Sale(SaleID),
	foreign key (BookID) references Book(BookID)
);
CREATE TABLE Import
(
	ImportID int primary key identity(1,1),
	ImportDate datetime not null,
	EmployeeID int,
	foreign key (EmployeeID) references Employee(EmployeeID)
);
CREATE TABLE ImportDetail
(
	ImportDetailID int primary key identity(1,1),
	ImportID int,
	BookID int,
	QuantityImported int not null,
	ImportCost decimal(10,2),
	foreign key (ImportID) references Import(ImportID),
	foreign key (BookID) references Book(BookID)
);