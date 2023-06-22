create table catigories
(
	id serial primary key not null,
	catigories text not null
);

create table tables
(
	id serial primary key not null,
	name text not null
);

Create table products
(
	id serial primary key not null,
	catigory_id serial not null,
	name text not null,
	price real not null,
	img_path varchar not null
);