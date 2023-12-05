use master
go
if exists(select * from sys.databases where name = 'GuinaLanches')
drop database GuinaLanches
create database GuinaLanches
go
use GuinaLanches
go

create table Images(
	ID int identity primary key,
	Picture varbinary(MAX) not null
);
go
 
create table Users(
	ID int identity primary key,
	Name varchar(80) not null,
	Email varchar(80) not null,
	Password varchar(MAX) not null,
	IsAdm bit not null,
	Salt varchar(200) not null,
	);
go

create table Requests(
	ID int identity primary key,
	UserID int references Users(ID) not null,
	Total float not null,
	IsRedy bit not null,
	IsDelivered bit not null
);
go

create table Products(
	ID int identity primary key,
	Name varchar(100) not null,
	Description varchar(150) not null,
	Type int not null,
	Price float not null,
	OffersPrice float,
	IsOffers bit not null,
);
go

create table ProductsRequests(
	ID int identity primary key,
	ProductID int references Products(ID) not null,
	RequestID int references Requests(ID) not null,
	Quantity int not null,
);
go




