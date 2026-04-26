A simple programm, just for fun of books DB using MySQL

First run this in MySQL:
-----------------------------------------------
DROP DATABASE IF EXISTS bookDB;
CREATE DATABASE bookDB;
USE BookDB;

CREATE TABLE book(
	id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    titolo VARCHAR(100) NOT NULL,
    autore VARCHAR(30) NOT NULL,
    pagine VARCHAR(15) NOT NULL,
    data_pubblicazione VARCHAR(6) NOT NULL
);
------------------------------------------------
