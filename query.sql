use master
go
if exists(select * from sys.databases where name = 'GuinaLanches')
drop database GuinaLanches
create database GuinaLanches
go
use GuinaLanches
go
 
create table Cliente(
	ID int identity primary key,
	Nome varchar(80) not null,
	Senha varchar(MAX) not null,
	Salt varchar(200) not null,
	);
go


