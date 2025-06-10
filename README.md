Food Ordering System

 Introduction
This is a food ordering management system built with C# WinForms and SQL Server, designed according to the 3-layer Architecture model:
- Presentation Layer (PL): User interface.
- Business Logic Layer (BL): Business logic processing.
- Data Access Layer (DAL): Connect and manipulate with SQL Server database.
![image](https://github.com/user-attachments/assets/54977ff2-a6d1-494d-9f9f-63dd514675e8)
![image](https://github.com/user-attachments/assets/a71c6783-f621-47d1-b7cc-0fd5bc1fb109)
![image](https://github.com/user-attachments/assets/51483c0c-2dbc-4b7a-970e-2639f8ecea11)
![image](https://github.com/user-attachments/assets/979b5f13-db0b-48b2-b187-4efc9d167992)
![image](https://github.com/user-attachments/assets/e06aad6a-49c2-45f0-9260-35fbef0dc1a2)
![image](https://github.com/user-attachments/assets/eb76b8d0-d4c6-4812-a024-035249464113)
![image](https://github.com/user-attachments/assets/b12727e0-d1af-45c1-8e25-9a85d9c0dc74)



 Main functions
- Display product list by category as rectangular frames.

- Click on product image to view detailed information.

- Place orders and save order information to the database.

- Manage users and orders.

- Manage products and product categories.

 Technology used
- Programming language: C# WinForms.

- Database: SQL Server.

- Framework: .NET Framework 4.8.

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
