CREATE DATABASE InventoryManagementSystem;  
USE InventoryManagementSystem;



-- Create Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    SKU NVARCHAR(50) UNIQUE NOT NULL,
    Category NVARCHAR(50) NULL,
    Quantity INT DEFAULT 0,
    UnitPrice DECIMAL(10, 2) NULL,
    Barcode NVARCHAR(50) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

-- Create Suppliers Table
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    SupplierName NVARCHAR(100) NOT NULL,
    ContactName NVARCHAR(100) NULL,
    Phone NVARCHAR(15) NULL,
    Email NVARCHAR(100) NULL,
    Address NVARCHAR(255) NULL
);

-- Create PurchaseOrders Table
CREATE TABLE PurchaseOrders (
    PurchaseOrderID INT PRIMARY KEY IDENTITY(1,1),
    SupplierID INT FOREIGN KEY REFERENCES Suppliers(SupplierID),
    OrderDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Completed', 'Cancelled')),
    TotalAmount DECIMAL(10, 2) NULL
);

-- Create PurchaseOrderDetails Table
CREATE TABLE PurchaseOrderDetails (
    PODetailID INT PRIMARY KEY IDENTITY(1,1),
    PurchaseOrderID INT FOREIGN KEY REFERENCES PurchaseOrders(PurchaseOrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL
);

-- Create SalesOrders Table
CREATE TABLE SalesOrders (
    SalesOrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Shipped', 'Cancelled')),
    TotalAmount DECIMAL(10, 2) NULL
);

-- Create SalesOrderDetails Table
CREATE TABLE SalesOrderDetails (
    SODetailID INT PRIMARY KEY IDENTITY(1,1),
    SalesOrderID INT FOREIGN KEY REFERENCES SalesOrders(SalesOrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL
);

-- Create StockMovements Table
CREATE TABLE StockMovements (
    MovementID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    MovementType NVARCHAR(20) CHECK (MovementType IN ('IN', 'OUT', 'ADJUSTMENT')),
    Quantity INT NOT NULL,
    MovementDate DATETIME DEFAULT GETDATE(),
    Description NVARCHAR(255) NULL
);

-- Create Users Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'Manager', 'Staff')),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Create AuditLogs Table
CREATE TABLE AuditLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Action NVARCHAR(100) NOT NULL,
    TableAffected NVARCHAR(50) NULL,
    ActionTime DATETIME DEFAULT GETDATE(),
    Description NVARCHAR(255) NULL
);

-- Create Categories Table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) UNIQUE NOT NULL,
    Description NVARCHAR(255) NULL
);


-- Insert Dummy Data into Products
INSERT INTO Products (Name, SKU, Category, Quantity, UnitPrice, Barcode)
VALUES 
('Product A', 'SKU001', 'Category 1', 100, 10.00, '1234567890123'),
('Product B', 'SKU002', 'Category 1', 50, 15.50, '1234567890124'),
('Product C', 'SKU003', 'Category 2', 200, 5.75, '1234567890125');

-- Insert Dummy Data into Suppliers
INSERT INTO Suppliers (SupplierName, ContactName, Phone, Email, Address)
VALUES 
('Supplier A', 'Contact A', '123-456-7890', 'contactA@example.com', '123 Supplier St.'),
('Supplier B', 'Contact B', '098-765-4321', 'contactB@example.com', '456 Supplier Ave.');

-- Insert Dummy Data into PurchaseOrders
INSERT INTO PurchaseOrders (SupplierID, OrderDate, Status, TotalAmount)
VALUES 
(1, GETDATE(), 'Pending',  1500.00),
(2, GETDATE(), 'Completed', 750.00);

-- Insert Dummy Data into PurchaseOrderDetails
INSERT INTO PurchaseOrderDetails (PurchaseOrderID, ProductID, Quantity, UnitPrice)
VALUES 
(1, 1, 100, 10.00),
(1, 2, 50, 15.50),
(2, 3, 100, 5.75);

-- Insert Dummy Data into SalesOrders
INSERT INTO SalesOrders (CustomerName, OrderDate, Status, TotalAmount)
VALUES 
('Customer A', GETDATE(), 'Shipped', 200.00),
('Customer B', GETDATE(), 'Pending', 300.00);

-- Insert Dummy Data into SalesOrderDetails
INSERT INTO SalesOrderDetails (SalesOrderID, ProductID, Quantity, UnitPrice)
VALUES 
(1, 1, 10, 10.00),
(1, 2, 5, 15.50),
(2, 3, 20, 5.75);

-- Insert Dummy Data into StockMovements
INSERT INTO StockMovements (ProductID, MovementType, Quantity, Description)
VALUES 
(1, 'IN', 100, 'Initial stock'),
(2, 'OUT', 5, 'Sold 5 units of Product B'),
(3, 'ADJUSTMENT', -10, 'Damaged stock');

-- Insert Dummy Data into Users
INSERT INTO Users (Username, PasswordHash, Role)
VALUES 
('admin', 'hashed_password_1', 'Admin'),
('manager', 'hashed_password_2', 'Manager'),
('staff', 'hashed_password_3', 'Staff');

-- Insert Dummy Data into AuditLogs
INSERT INTO AuditLogs (UserID, Action, TableAffected, Description)
VALUES 
(1, 'Created Product A', 'Products', 'Added new product to inventory'),
(2, 'Updated Stock for Product B', 'StockMovements', 'Adjusted stock levels');

-- Insert Dummy Data into Categories
INSERT INTO Categories (CategoryName, Description)
VALUES 
('Category 1', 'Description for Category 1'),
('Category 2', 'Description for Category 2');






-- Select all records from Products table
SELECT * FROM Products;

-- Select all records from Suppliers table
SELECT * FROM Suppliers;

-- Select all records from PurchaseOrders table
SELECT * FROM PurchaseOrders;

-- Select all records from PurchaseOrderDetails table
SELECT * FROM PurchaseOrderDetails;

-- Select all records from SalesOrders table
SELECT * FROM SalesOrders;

-- Select all records from SalesOrderDetails table
SELECT * FROM SalesOrderDetails;

-- Select all records from StockMovements table
SELECT * FROM StockMovements;

-- Select all records from Users table
SELECT * FROM Users;

-- Select all records from AuditLogs table
SELECT * FROM AuditLogs;

-- Select all records from Categories table
SELECT * FROM Categories;