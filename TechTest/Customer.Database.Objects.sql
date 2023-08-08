USE [Customers]
GO

IF OBJECT_ID('dbo.Customer') IS NOT NULL
BEGIN
  DROP TABLE [dbo].[Customer]
END
GO

CREATE TABLE [dbo].[Customer]
(
  CustomerId INT IDENTITY NOT NULL PRIMARY KEY,
  Name VARCHAR(200) NOT NULL,
  Country VARCHAR(2) NOT NULL,
  DateOfBirth DATETIME NOT NULL

)