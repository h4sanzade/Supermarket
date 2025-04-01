# Market Application Project Explanation

 Overview
This C# console application simulates a market system with two main panels: User Panel and Admin Panel. The application allows users to register, login, browse products by category, add products to cart, checkout, and view their shopping history. Admins can manage the inventory by adding, updating, or removing products, managing categories, and viewing sales reports and statistics.

 Key Components

 1. User Management
- **User Registration and Login**: Users can create accounts with a username, password, and email address.
- **Profile Management**: Users can view and update their profile information.

 2. Product and Inventory Management
- **Product Catalog**: Products are organized by categories (Fruits, Vegetables, Meat Products, Beverages, Sweets, Dairy Products, Canned Products).
- **Stock Tracking**: The system keeps track of product stock levels and updates them when users make purchases.
- **Category Management**: Admins can add or update product categories.

 3. Shopping Features
- **Shopping Cart System**: Users can add products to cart, view cart contents, and remove products from cart.
- **Checkout Process**: Users can complete purchases by providing payment, with the system calculating change.
- **Shopping History**: The system records user purchase history for later reference.

 4. Admin Features
- **Admin Authentication**: Secure login for administrators.
- **Inventory Management**: Ability to add, update, or remove products from the inventory.
- **Reporting**: Generate reports about sales and stock levels.
- **Statistics**: View statistics about product performance and sales.

 ## Application Flow

Main Menu
The application starts with a main menu offering three options:
1. User Panel
2. Admin Panel
3. Exit

User Panel Flow
1. **Registration/Login**: User can register a new account or login to an existing one.
2. **User Actions Menu**: After login, users can:
   - View product categories
   - View and manage their shopping cart
   - Complete checkout process
   - View and update their profile
   - View shopping history
   - Logout

Admin Panel Flow
1. **Login**: Admin authentication with predefined credentials.
2. **Admin Actions Menu**: After login, admins can:
   - Manage product stock (add, update, remove products)
   - Manage product categories
   - View sales reports
   - View statistics
   - Logout

## Key Functions Explained

Product Management
- `AddProduct`: Adds new products to the inventory
- `UpdateProduct`: Modifies existing product details
- `RemoveProduct`: Removes products from the inventory

Shopping Process
- `ViewCategories`: Displays available product categories and allows users to select products
- `ViewCart`: Shows the current contents of the user's shopping cart
- `RemoveCart`: Allows users to remove items from their cart
- `Checkout`: Processes payment and completes the purchase

Admin Functions
- `ManageStock`: Interface for adding, updating, or removing products
- `ManageCategories`: Interface for adding or updating product categories
- `GenerateReports`: Creates sales and inventory reports
- `DisplayStatistics`: Shows various statistics about product sales and inventory

User Account Management
- `Register`: Creates new user accounts
- `Login`: Authenticates users
- `UpdateProfile`: Updates user profile information
- `ViewProfile`: Displays user account information

## Data Structures

User and Admin
- Basic authentication and profile information

Product
- Properties: ProductId, ProductName, Price, Stock, InitialStock, Category

Cart
- Collection of products
- Methods for adding/removing products and calculating total price

Inventory
- Collection of all products
- Methods for managing products and generating reports

UserShoppingHistoryManager
- Records and displays user purchase history

## Error Handling
The application implements try-catch blocks throughout to handle unexpected user inputs and other potential errors, ensuring that the application continues running without crashing.
