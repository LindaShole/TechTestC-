create database TechTest

CREATE TABLE Customer (
    CustomerID int,
    Name varchar(255),
    Country varchar(255),
    DateOFBirth varchar(255)
   
);

CREATE TABLE Orders (
    OrderID int,
    Amount float,
    Vat float
)