use master;
go
drop database if exists solar;
go
create database solar;
go

use solar;

create table power_supply_types(
id int not null primary key identity(1,1),
name varchar(100) not null,
);

create table instalation_types(
id int not null primary key identity(1,1),
name varchar(100) not null,
);

create table production(
id int not null primary key identity(1,1),
location int,
consumption_24 int,
solar_production_24 int,
date datetime,
);

create table location(
id int not null primary key identity(1,1),
site_id int,
site_name varchar,
instalation_type int,
power_supply_type int,
);


alter table location add foreign key (instalation_type) references instalation_types(id);
alter table location add foreign key (power_supply_type) references power_supply_types(id);
alter table production add foreign key (location) references location(id);

insert into power_supply_types (name) values ('hybrid 24V');

insert into grupe (naziv, smjer,maxpolaznika)
values ('WP5',1,26);

select * from power_supply_types;