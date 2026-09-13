# c-sharp-bikesop-project

এখানে আপনার **Bike Shop Management System** প্রজেক্টের জন্য একটি সম্পূর্ণ, প্রফেশনাল এবং সুন্দরভাবে সাজানো **GitHub `README.md**` ফাইল দেওয়া হলো। এটি সরাসরি কপি করে আপনার গিটহাব রিপোজিটরির `README.md` ফাইলে পেস্ট করে দিতে পারেন।

---

# 🚴‍♂️ Bike Shop Management System

A comprehensive desktop application for bike sales, inventory stock control, customer order processing, and staff management built using **C# Windows Forms** and **Microsoft SQL Server**.

---

## 📌 Project Overview

The **Bike Shop Management System** is designed to digitize and streamline the daily operations of a bike showroom. It addresses common retail challenges such as inventory tracking, sales recording, order fulfillment, and employee salary management by placing all business workflows on top of a centralized, normalized relational database (`BShopM`).

The application features a single executable with **role-based navigation** tailored for three distinct user types:

* **Customers:** Browse bikes, place orders, and track purchase history.
* **Employees:** Process pending orders, manage counter sales with discounts, and view sales performance.
* **Administrator:** Manage showroom catalogue (stock/pricing), employee credentials, and payroll.

---

## ✨ Key Features & Facilities

* 🔐 **Role-Based Access Control:** Role-driven UI routing for Customers, Employees, and Administrators upon login.
* 📝 **Customer Self-Registration:** Built-in form validation (email format, matching passwords, phone number, and age limit check 18+).
* 🏍️ **Catalogue & Inventory Management:** Live stock updates and catalogue management for bike brands, models, and pricing.
* ⚡ **Automatic Stock Control:** Automatically decrements stock levels upon order confirmation/sale. Prevents selling items that are out of stock.
* 🛒 **Two-Stage Order Processing:** Customers place pending orders; staff members accept or decline them based on current inventory.
* 🏷️ **Discount & Invoicing:** Integrated checkout calculator with customizable percentage-based discounts.
* 📊 **Sales Reporting & History:** Staff can filter sales history by date ranges and monitor personal sales figures.
* 🛡️ **Referential Integrity:** Enforced Foreign Key constraints to prevent deleting customer profiles with active pending orders.
* ⚙️ **Centralized Connection:** Connection string centralized in `ApplicationHelper.cs` for easy machine setup.

---

## 📐 Database Schema & Architecture

The system utilizes **6 normalized (3NF) relational tables** hosted on Microsoft SQL Server:

```
+------------------+         +----------------+         +------------------+
|  RegistraTable   | <------ |   OrderTable   | ------> |  BikeInfoTable   |
|   (Customers)    | (1---M) | (Pending Order)| (M---1) |    (Products)    |
+------------------+         +----------------+         +------------------+
         ^                                                       ^
         | (Logical Link)                         (Logical Link) |
         v                                                       v
+------------------+                                    +------------------+
|    SalesTable    | <----------------------------------| OfficeLoginTable |
| (Confirmed Sale) |                (1---M)             |     (Staff)      |
+------------------+                                    +------------------+
                                                                 | (1---M)
                                                                 v
                                                        +------------------+
                                                        |   ESalaryTable   |
                                                        |     (Salary)     |
                                                        +------------------+

```

### Table Summary:

1. `RegistraTable`: Stores registered customer profiles.
2. `OfficeLoginTable`: Holds credentials and user roles (`Admin` / `Employee`) for staff.
3. `ESalaryTable`: Maintains salary information linked to staff IDs (`ON DELETE CASCADE`).
4. `BikeInfoTable`: Maintains bike stock levels, brand, model, and price.
5. `OrderTable`: Pending orders awaiting staff approval (`FK` to `RegistraTable`).
6. `SalesTable`: Archived transaction records including sale date and reference staff name.

---

## 🗄️ Database Setup (SQL Script)

To set up the database locally, execute the following SQL script in **SQL Server Management Studio (SSMS)**:

```sql
CREATE DATABASE BShopM;
GO
USE BShopM;
GO

-- 1. Customer Table
CREATE TABLE RegistraTable (
    ID        INT           IDENTITY(1,1) NOT NULL,
    Name      VARCHAR(100)                NOT NULL,
    Email     VARCHAR(100)                NOT NULL,
    Phone     VARCHAR(20)                 NOT NULL,
    Password  VARCHAR(50)                 NOT NULL,
    CONSTRAINT PK_RegistraTable  PRIMARY KEY (ID),
    CONSTRAINT UQ_Registra_Email UNIQUE (Email)
);

-- 2. Staff Table
CREATE TABLE OfficeLoginTable (
    ID        INT           IDENTITY(1,1) NOT NULL,
    Name      VARCHAR(100)                NOT NULL,
    Email     VARCHAR(100)                NOT NULL,
    Password  VARCHAR(50)                 NOT NULL,
    Usertype  VARCHAR(20)                 NOT NULL,
    CONSTRAINT PK_OfficeLoginTable PRIMARY KEY (ID),
    CONSTRAINT UQ_Office_Email     UNIQUE (Email),
    CONSTRAINT CK_Office_Usertype  CHECK (Usertype IN ('Admin','Employee'))
);

-- 3. Salary Table
CREATE TABLE ESalaryTable (
    ID      INT IDENTITY(1,1) NOT NULL,
    OLID    INT               NOT NULL,
    Salary  INT               NOT NULL,
    CONSTRAINT PK_ESalaryTable   PRIMARY KEY (ID),
    CONSTRAINT FK_ESalary_Office FOREIGN KEY (OLID)
        REFERENCES OfficeLoginTable(ID) ON DELETE CASCADE,
    CONSTRAINT CK_ESalary_Salary CHECK (Salary >= 0)
);

-- 4. Product / Bike Catalogue Table
CREATE TABLE BikeInfoTable (
    ID     INT         IDENTITY(1,1) NOT NULL,
    Brand  VARCHAR(50)               NOT NULL,
    Model  VARCHAR(50)               NOT NULL,
    Price  INT                       NOT NULL,
    Stock  INT                       NOT NULL DEFAULT 0,
    CONSTRAINT PK_BikeInfoTable   PRIMARY KEY (ID),
    CONSTRAINT UQ_Bike_BrandModel UNIQUE (Brand, Model),
    CONSTRAINT CK_Bike_Price      CHECK (Price >= 0),
    CONSTRAINT CK_Bike_Stock      CHECK (Stock >= 0)
);

-- 5. Pending Order Table
CREATE TABLE OrderTable (
    Orderid     INT           IDENTITY(1,1) NOT NULL,
    Customerid  INT                         NOT NULL,
    Brand       VARCHAR(50)                 NOT NULL,
    Model       VARCHAR(50)                 NOT NULL,
    Quantity    INT                         NOT NULL,
    Total       DECIMAL(18,2)               NOT NULL,
    CONSTRAINT PK_OrderTable     PRIMARY KEY (Orderid),
    CONSTRAINT FK_Order_Registra FOREIGN KEY (Customerid)
        REFERENCES RegistraTable(ID),
    CONSTRAINT CK_Order_Quantity CHECK (Quantity > 0),
    CONSTRAINT CK_Order_Total    CHECK (Total >= 0)
);

-- 6. Confirmed Sales Table
CREATE TABLE SalesTable (
    ID          INT           IDENTITY(1,1) NOT NULL,
    Customerid  INT                         NOT NULL,
    Email       VARCHAR(100)                NOT NULL,
    Brand       VARCHAR(50)                 NOT NULL,
    Model       VARCHAR(50)                 NOT NULL,
    Quantity    INT                         NOT NULL,
    Total       DECIMAL(18,2)               NOT NULL,
    Reference   VARCHAR(50)                 NOT NULL,
    Date        DATE                        NOT NULL,
    CONSTRAINT PK_SalesTable     PRIMARY KEY (ID),
    CONSTRAINT CK_Sales_Quantity CHECK (Quantity > 0),
    CONSTRAINT CK_Sales_Total    CHECK (Total >= 0)
);

-- Sample Initial Data
INSERT INTO OfficeLoginTable VALUES
    ('Nihar Sarkar', 'admin@bikeshop.com',  'admin123', 'Admin'),
    ('Rakib Hasan',  'rakib@bikeshop.com',  'emp123',   'Employee');

INSERT INTO BikeInfoTable VALUES
    ('Yamaha', 'R15 V4',       550000, 10),
    ('Yamaha', 'FZS V3',       285000, 12),
    ('Honda',  'CBR 150R',     610000,  6);

```

---

## 🚀 Getting Started & Installation

### Prerequisites

* **Visual Studio 2019 / 2022** (with .NET Desktop Development workload installed)
* **Microsoft SQL Server / SQLEXPRESS**
* **SQL Server Management Studio (SSMS)**

### Steps to Run

1. **Clone the Repository:**
```bash
git clone https://github.com/your-username/bike-shop-management-system.git

```


2. **Setup Database:**
* Open SSMS and run the provided SQL script to create the `BShopM` database and tables.


3. **Configure Connection String:**
* Open the project solution in Visual Studio.
* Navigate to `ApplicationHelper.cs`.
* Update the `cs` string with your machine's SQL Server instance name:
```csharp
public static string cs = @"Data Source=YOUR_SERVER_NAME\SQLEXPRESS;Initial Catalog=BShopM;Integrated Security=True;Encrypt=False";

```




4. **Build and Run:**
* Press `F5` or click **Start** in Visual Studio to launch the application.



---

## 🛠️ Technology Stack

* **Language:** C#
* **Framework:** .NET Framework (Windows Forms)
* **Database:** Microsoft SQL Server (SQLEXPRESS)
* **Data Access:** ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`)
* **IDE:** Visual Studio

---

## 👥 Contributors & Academic Details

* **Institution:** American International University–Bangladesh (AIUB)
* **Faculty:** Faculty of Science and Technology (Department of Computer Science)
* **Course:** Object Oriented Programming 2 (Summer, 2025-26) [Section: D]
* **Supervised By:** Dr. Md. Iftekharul Mobin

### Development Team:

* **Md Jabed Iqbal Naquib** — *ID: 24-58175-2*
* **Nashia Bentha Kamal** — *ID: 24-58420-2*
* **Sams Ridwan Simran** — *ID: 24-57685-2*
* **Osman Bin Tarik** — *ID: 24-58331-2*
