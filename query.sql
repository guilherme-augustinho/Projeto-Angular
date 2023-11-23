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
Nome varchar(100) not null,
Senha varchar(100) not null,
DataNasc date not null
);
go