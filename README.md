 Food Ordering System

 Introduction
This is a food ordering management system built with C WinForms and SQL Server, designed according to the 3-layer Architecture model:
- Presentation Layer (PL): User interface.
- Business Logic Layer (BL): Business logic processing.
- Data Access Layer (DAL): Connect and manipulate with SQL Server database.

 Main functions
- Display product list by category as rectangular frames.

- Click on product image to view detailed information.

- Place orders and save order information to the database.

- Manage users and orders.

- Manage products and product categories.

 Technology used
- Programming language: C WinForms.

- Database: SQL Server.

- Framework: .NET Framework 4.7.2.

 Database Structure
- Product: ProductID, ProductName, Price, Description, CategoryID, Image, Address.
- Category: CategoryID, CategoryName.
- Order: OrderID, UserID, OrderDate, TotalAmount.
- OrderDetail: OrderDetailID, OrderID, ProductID, Quantity, Price.
- User: UserID, UserName, Password, FullName, Address, PhoneNumber.

 Installation Instructions
1. Open Visual Studio and download the project.

2. Configure the connection string in the `app.config` file.

3. Create a SQL Server database according to the described structure.

4. Build and run the program.

 Instructions for use
1. Select a product from the main interface.

2. Click on the product image to view details.

3. Add the product to the cart and proceed to order.

 Contribute
For any contributions, please create a Pull Request or contact us directly via email.

 Copyright
This project is copyrighted by Binh Ca.
