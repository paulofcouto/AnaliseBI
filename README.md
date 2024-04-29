# AnaliseBI


CREATE DATABASE IF NOT EXISTS stage;
USE stage;

CREATE TABLE IF NOT EXISTS stage.MultiStore (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    OrderID VARCHAR(255),
    OrderDate DATETIME,
    ShipDate DATETIME,
    ShipMode VARCHAR(255),
    CustomerID VARCHAR(255),
    CustomerName VARCHAR(255),
    CustomerAge INT,
    CustomerBirthday DATE,
    CustomerState VARCHAR(255),
    Segment VARCHAR(255),
    Country VARCHAR(255),
    City VARCHAR(255),
    State VARCHAR(255),
    RegionalManagerID VARCHAR(255),
    RegionalManager VARCHAR(255),
    PostalCode VARCHAR(255),
    Region VARCHAR(255),
    ProductID VARCHAR(255),
    Category VARCHAR(255),
    SubCategory VARCHAR(255),
    ProductName VARCHAR(255),
    Sales DECIMAL(18, 2),
    Quantity INT,
    Discount DECIMAL(18, 2),
    Profit DECIMAL(18, 2)
);