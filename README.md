# Project Setup Instructions


## Setting Up Visual Studio Project
 
1. **.NET Framework**
   - This project is running on .Net Framework Version 4.8, You Will need to download the Framework is you currently dont have it install link is below.
   - [.Net Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)

2. **Entity Framework**  
   - This Project uses the Entity Framework Firefly 
   - which handles ORM and Logging in
   
3. **Project Referances**
   - The Project Referances have been included in the project should any referances be missing you can navigate the project folder in windows to find all dll's needed
   - most important dll's (ENV.dll, Firefly.Box.Dll,interop.SHDocVw.dll, Axinterop.SHDocVw.dll, itextsharp.dll, Oracle.ManagedDataAccess.dll )
   
4. **Build Project**
   - You must clean and build project before running the project 
   - Onece project is built successfully, you ready to run the application  
   - Note should you get an ERROR(A project with an Output Type Class Library cannot be started directly). 
   - Soultions is to got to Properties on (Solution 'EMS'(7 of 7 Projects))
   - Select startup Project and set signle startup project to (EMS) note it might be set to ENV when you git clone the project   
   
## Setting Up the Database

1. **Create Database **
   - Set Schema to master
   - Execute the SQL script provided below to create the database `FLM`.
   

2. **Modify `EMS.ini` file located in the EMS project:**
   - You will need to change the Server name to the server you created the database on note that the user name and passwrod is created by the script, should you want to change
	 you can int EMS.ini file.
   - You can edit the EMS.ini file in visual studio or with the normal notepad, look line 219 to 223 for database settings in the EMS.ini file 
   - **Note:** You don't need to change the database name (`FLM`), username (FLM`), and password (`1234`) due to my script creating them automatically.
   
   Example of `EMS.ini`:
   ```ini
   //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Database Connection HERE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
   MSSQLDatabaseEnabled = Y
	MSSQLDatabaseName= FML				
	MSSQLServerName= LAPITS125\SQLEXPRESS	
	MSSQLUsername= FML				
	MSSQLSPassword= 1234


-----------------BEGINNING OF SCRIPT----------------------------------

----Create the database FLM if it does not exist----------

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FLM')
BEGIN
    CREATE DATABASE FLM;
END
GO

-- Use the FLM database
USE FLM;
GO

-- Create the Branch table
CREATE TABLE Branch (
    ID INT PRIMARY KEY NOT NULL, 
    Name VARCHAR(100) NOT NULL,      
    TelephoneNumber VARCHAR(15) NULL, 
    OpenDate DATETIME NOT NULL,       
	Status Char NOT NULL 
);
GO

-- Create the Product table
CREATE TABLE Product (
    ID INT PRIMARY KEY NOT NULL, 
    Name VARCHAR(100) NOT NULL,       
    WeightedItem BIT NOT NULL,        --if the item is sold by weight (1 = Yes, 0 = No)
    SuggestedSellingPrice DECIMAL(14, 2) NOT NULL, 
	Status Char Not Null 
);
GO

-- Create the Branch_Product table for many-to-many relationship
CREATE TABLE Branch_Product (
    BranchID INT NOT NULL,  -- Foreign key referencing Branch
    ProductID INT NOT NULL, -- Foreign key referencing Product
    PRIMARY KEY (BranchID, ProductID), -- Composite primary key
);
GO

CREATE LOGIN FLM WITH PASSWORD = '1234', CHECK_POLICY = OFF;
GO

-- Create user 'FLM' mapped to login 'FLM' with default schema 'dbo'
CREATE USER FLM FOR LOGIN FLM WITH DEFAULT_SCHEMA = dbo;
GO

-- Assign necessary permissions to 'easy'
GRANT SELECT, INSERT, UPDATE, DELETE ON Schema::dbo TO FLM;
GO

---------------------------------------END OF SCRIPT----------------------
	
	

