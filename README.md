# Shop POS — Point of Sale System

A desktop Point of Sale (POS) application built with **C# Windows Forms** and a **SQL Server LocalDB** backend. It covers the core workflow of a small shop: logging in, managing categories/products/customers, ringing up a sale, and reviewing sales history.

---

## ✨ Features

- **User authentication** — Login and Register screens backed by a `Login` table
- **Category management** — add, update, delete, and search product categories
- **Product management** — add, update, delete, and search products, with category assignment, unit price, and stock tracking
- **Customer management** — add, update, delete, and search customers
- **New Sale / Billing** — pick a customer, search/select products, build a cart, apply a discount, and save the sale (auto-decrements stock)
- **Sales history** — filter past sales by bill number or date range, and drill into a bill's line-item details
- **Consistent modern UI** — every form follows the same dark navy header + white rounded-card + icon-labeled design language

---

## 🛠️ Tech Stack

| Layer            | Technology                        |
|-------------------|------------------------------------|
| UI                | C# Windows Forms (.NET)           |
| Database          | SQL Server LocalDB (`.mdf` file)  |
| Data access       | ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`) |

---

## 📁 Forms in this project

| Form                          | Purpose                                                   |
|-------------------------------|------------------------------------------------------------|
| `Form1` (Login)                | Username/password sign-in, links to Register and Exit     |
| `RegisterForm`                 | Create a new login (username + password, with confirmation) |
| `Form2` (Dashboard)            | Central hub with tiles linking to every management screen |
| `Form3` (Category Management)  | CRUD for product categories                                |
| `ProductManagementForm`        | CRUD for products (name, category, price, stock)           |
| `Customer_Management_Form`     | CRUD for customers                                          |
| `New_Sale_Form`                | Build and save a new sale/bill                              |
| `Sales_History_Form`           | Search past sales by bill number or date range              |
| `Sale_Details_Form`            | Read-only breakdown of a single bill's line items and total |
| `Exit_Confirmation_Form`       | Confirms before closing the application                     |

---

## 🗄️ Database Schema (expected tables)

- **Login** — `Username`, `Password`
- **Categories** — `CategoryID`, `CategoryName`, `Description`
- **Products** — `ProductID`, `ProductName`, `CategoryID`, `UnitPrice`, `StockQuantity`
- **Customers** — `CustomerID`, `CustomerName`, `ContactNumber`, `Address`
- **Sale** — `SaleID`, `SaleDate`, `CustomerID`, `GrandTotal`
- **SaleDetails** — `SaleDetailID`, `SaleID`, `ProductID`, `Quantity`, `UnitPrice`, `LineTotal`

> ⚠️ Table names must be consistent everywhere they're referenced (e.g. `Products` not `Product`, `Categories` not `Category`, `Customers` not `Customer`). A number of earlier bugs in this project came from that exact mismatch.

---

## 🚀 Getting Started

1. Open the solution in **Visual Studio**.
2. Make sure **SQL Server Express LocalDB** is installed (comes with Visual Studio's default workload).
3. Confirm the connection string in each form matches your local `.mdf` file path:
   ```
   Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="<path to your .mdf>";Integrated Security=True
   ```
4. Create the database tables listed above if they don't already exist.
5. Set `Form1` (Login) as the startup form in `Program.cs`.
6. **Clean → Rebuild** the solution before running, especially after pulling in new form files, to avoid Visual Studio launching a stale build.

---


## 📌 Notes

This project started as a coursework/learning exercise and has been iteratively debugged and redesigned form-by-form for visual consistency.# POS-System
