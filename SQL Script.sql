create database moviedb;

create table movies 
(
	id int not null auto_increment primary key,
    title varchar(40),
    genre varchar(30)
);

insert into movies
values(0, "Harry Potter and the Sourcerer's Stone", "Action"),
(0, "Home Alone", "Holiday"),
(0, "Elf", "Holiday"),
(0, "Star Wars IV", "Sci Fi"),
(0, "E.T.", "Sci Fi"),
(0, "Lord of the Rings", "Sci Fi"),
(0, "The Grinch", "Holiday"),
(0, "Black Panther", "Action"),
(0, "Wedding Crashers", "Comedy"),
(0, "Toy Story", "Animated"),
(0, "Mulan", "Animated");

select * from movies;