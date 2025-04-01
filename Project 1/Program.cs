using Project_1.Models;
using Project_1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Project_1
{
    class ProgramR
    {
        static void Main(string[] args)
        {

            UserService userService = new UserService();
            AdminService adminService = new AdminService();
            adminService.Register(new Admin { UserName = "hasanzade", Password = "hasanzade021" });
            Inventory inventory = new Inventory();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to the Market App");
                Console.WriteLine("1. User Panel");
                Console.WriteLine("2. Admin Panel");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                UserPanel(userService, inventory);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Please Enter Correctly!");
                            }
                            break;
                        case 2:
                            try
                            {
                                AdminPanel(adminService, inventory);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Please Enter Correctly!");
                            }
                            break;
                        case 3:
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please Enter Correctly!");
                }

            }
        }
        
        static void Productss(Inventory inventory)
        {
            AddProduct(inventory, new Product { ProductId = 1, ProductName = "Apple", Price = 2.0m, Stock = 50, InitialStock = 50, Category = "Fruits" });
            AddProduct(inventory, new Product { ProductId = 2, ProductName = "Pear", Price = 2.5m, Stock = 51, InitialStock = 51, Category = "Fruits" });
            AddProduct(inventory, new Product { ProductId = 3, ProductName = "Pomegranate", Price = 3.0m, Stock = 52, InitialStock = 52, Category = "Fruits" });
            AddProduct(inventory, new Product { ProductId = 4, ProductName = "Banana", Price = 1.5m, Stock = 53, InitialStock = 53, Category = "Fruits" });
            AddProduct(inventory, new Product { ProductId = 5, ProductName = "Cherry", Price = 4.0m, Stock = 54, InitialStock = 54, Category = "Fruits" });
            AddProduct(inventory, new Product { ProductId = 6, ProductName = "Strawberry", Price = 3.5m, Stock = 55, InitialStock = 55, Category = "Fruits" });

            AddProduct(inventory, new Product { ProductId = 7, ProductName = "Tomato", Price = 1.8m, Stock = 45, InitialStock = 45, Category = "Vegetables" });
            AddProduct(inventory, new Product { ProductId = 8, ProductName = "Lettuce", Price = 2.2m, Stock = 40, InitialStock = 40, Category = "Vegetables" });
            AddProduct(inventory, new Product { ProductId = 9, ProductName = "Potato", Price = 1.0m, Stock = 60, InitialStock = 60, Category = "Vegetables" });
            AddProduct(inventory, new Product { ProductId = 10, ProductName = "Zucchini", Price = 1.5m, Stock = 55, InitialStock = 55, Category = "Vegetables" });
            AddProduct(inventory, new Product { ProductId = 11, ProductName = "Pepper", Price = 2.5m, Stock = 48, InitialStock = 48, Category = "Vegetables" });

            AddProduct(inventory, new Product { ProductId = 12, ProductName = "Beef cuts", Price = 8.0m, Stock = 30, InitialStock = 30, Category = "Meat Products" });
            AddProduct(inventory, new Product { ProductId = 13, ProductName = "Chicken", Price = 5.0m, Stock = 40, InitialStock = 40, Category = "Meat Products" });
            AddProduct(inventory, new Product { ProductId = 14, ProductName = "Beef", Price = 9.0m, Stock = 25, InitialStock = 25, Category = "Meat Products" });
            AddProduct(inventory, new Product { ProductId = 15, ProductName = "Beef meatballs", Price = 6.5m, Stock = 35, InitialStock = 35, Category = "Meat Products" });

            AddProduct(inventory, new Product { ProductId = 16, ProductName = "Water", Price = 1.0m, Stock = 100, InitialStock = 100, Category = "Beverages" });
            AddProduct(inventory, new Product { ProductId = 17, ProductName = "Fruit juice", Price = 2.5m, Stock = 80, InitialStock = 80, Category = "Beverages" });
            AddProduct(inventory, new Product { ProductId = 18, ProductName = "Soft drinks", Price = 1.5m, Stock = 90, InitialStock = 90, Category = "Beverages" });
            AddProduct(inventory, new Product { ProductId = 19, ProductName = "Tea", Price = 3.0m, Stock = 70, InitialStock = 70, Category = "Beverages" });
            AddProduct(inventory, new Product { ProductId = 20, ProductName = "Coffee", Price = 4.0m, Stock = 60, InitialStock = 60, Category = "Beverages" });

            AddProduct(inventory, new Product { ProductId = 21, ProductName = "Chips", Price = 2.0m, Stock = 50, InitialStock = 50, Category = "Sweets" });
            AddProduct(inventory, new Product { ProductId = 22, ProductName = "Biscuit", Price = 1.5m, Stock = 55, InitialStock = 55, Category = "Sweets" });
            AddProduct(inventory, new Product { ProductId = 23, ProductName = "Chocolate", Price = 3.0m, Stock = 45, InitialStock = 45, Category = "Sweets" });
            AddProduct(inventory, new Product { ProductId = 24, ProductName = "Bread", Price = 2.5m, Stock = 48, InitialStock = 48, Category = "Sweets" });
            AddProduct(inventory, new Product { ProductId = 25, ProductName = "Cake", Price = 5.0m, Stock = 40, InitialStock = 40, Category = "Sweets" });


          
            AddProduct(inventory, new Product {ProductId = 26,ProductName = "Milk",Price = 1.2m,Stock = 70,InitialStock = 70,Category = "Dairy Products"});

            AddProduct(inventory, new Product{ProductId = 27, ProductName = "Cheese",Price = 3.0m,Stock = 55,InitialStock = 55,Category = "Dairy Products"});

            AddProduct(inventory, new Product{ ProductId = 28,ProductName = "Ice cream",Price = 4.5m,Stock = 42,InitialStock = 42,Category = "Dairy Products"});

            AddProduct(inventory, new Product{ProductId = 29,ProductName = "Yogurt",Price = 2.0m,Stock = 65,InitialStock = 65,Category = "Dairy Products"});

            // Canned Products
            AddProduct(inventory, new Product{ProductId = 30,ProductName = "Canned tuna",Price = 3.0m, Stock = 25,InitialStock = 25,Category = "Canned Products"});
            AddProduct(inventory, new Product{ProductId = 31,ProductName = "Canned fruits",Price = 2.5m,Stock = 30,InitialStock = 30,Category = "Canned Products"});

        }
        static void AddProduct(Inventory inventory, Product product)
        {

            inventory.AddProduct(product);
        }
        static void UserPanel(UserService userService, Inventory inventory)
        {
            try
            {
                Console.WriteLine("User Panel");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    userService.Register(new User { UserName = username, Password = password, Email = email });
                    Console.WriteLine("User registered successfully!");
                }
                else if (choice == 2)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    User user = userService.Login(username, password);
                    if (user != null)
                    {
                        Console.WriteLine("Login successful!");
                        UserActions(user, inventory, userService);
                    }
                    else
                    {
                        Console.WriteLine("Invalid credentials!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Correctly!");
            }
        }
        static void UserActions(User user, Inventory inventory, UserService userService)
        {

            Cart cart = new Cart();
            UserShoppingHistoryManager historyManager = new UserShoppingHistoryManager(user.UserName);

            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("1. View Categories");
                    Console.WriteLine("2. View Cart");
                    Console.WriteLine("3. Remove From Cart");
                    Console.WriteLine("4. Checkout");
                    Console.WriteLine("5. View Profile");
                    Console.WriteLine("6. Update Profile");
                    Console.WriteLine("7. View Shopping History");
                    Console.WriteLine("8. Logout");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            ViewCategories(inventory, cart);
                            break;
                        case 2:
                            ViewCart(cart);
                            break;
                        case 3:
                            RemoveCart(cart);
                            break;
                        case 4:
                            Checkout(cart, historyManager);
                            break;
                        case 5:
                            ViewProfile(user);
                            break;
                        case 6:
                            UpdateProfile(user, userService);
                            break;
                        case 7:

                            historyManager.DisplayHistory();
                            break;
                        case 8:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please Enter Correctly!");
                }
            }
        }
        static void ViewCategories(Inventory inventory, Cart cart)
        {
            try
            {
                Console.WriteLine("Categories:");
                var categories = inventory.Products.Select(p => p.Category).Distinct().ToList();
                for (int i = 0; i < categories.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {categories[i]}");
                }
                int categoryChoice = int.Parse(Console.ReadLine()) - 1;
                string selectedCategory = categories[categoryChoice];

                var products = inventory.Products.Where(p => p.Category == selectedCategory && p.Stock > 0).ToList();
                if (products.Count == 0)
                {
                    Console.WriteLine("No products available in this category.");
                    return;
                }
                Console.WriteLine($"Products in category '{selectedCategory}':");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i].ProductName} - {products[i].Price} (Stock: {products[i].Stock})");
                }

                Console.WriteLine("Hello world");
                int a = 3;
                if(a == 3)
                {
                    Console.WriteLine("Helloooo");
                }
                Console.WriteLine("Hello world");


                Console.WriteLine("Select a product to add to cart (or enter 0 to go back):");
                int productChoice = int.Parse(Console.ReadLine()) - 1;

                if (productChoice == -1)
                {
                    return;
                }
                else if (productChoice < 0 || productChoice >= products.Count)
                {
                    Console.WriteLine("Invalid product choice.");
                    return;
                }
                cart.AddProduct(products[productChoice]);
                Console.WriteLine("Product added to cart!");
                products[productChoice].Stock--;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Correctly!");
            }
        }
        static void ViewCart(Cart cart)
        {
            Console.WriteLine("Cart:");
            int productId = 0;
            foreach (var product in cart.Products)
            {
                productId += 1;
                Console.WriteLine($"{productId}. {product.ProductName} - {product.Price}");
            }
            Console.WriteLine($"Total Price: {cart.TotalPrice}");
        }
        static void RemoveCart(Cart cart)
        {
            try
            {
                Console.Write("Enter product ID to remove from cart: ");
                int productId = int.Parse(Console.ReadLine());
                cart.RemoveProduct(productId);
                Console.WriteLine("Product removed from cart!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Correctly!");
            }

        }
        static void Checkout(Cart cart, UserShoppingHistoryManager historyManager)
        {
            try
            {
                Console.WriteLine($"Total Price: {cart.TotalPrice}");
                Console.Write("Enter payment amount: ");
                decimal payment = decimal.Parse(Console.ReadLine());
                decimal change = cart.Checkout(payment, historyManager);
                if (change == -1)
                {
                    Console.WriteLine("Not enough!");
                }
                else if (change != -2)
                {
                    Console.WriteLine("Your cart is empty!");
                }
                else
                {
                    Console.WriteLine($"Change: {change}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Please Enter Correctly!");
            }
        }
        static void ViewProfile(User user)
        {
            Console.WriteLine($"Username: {user.UserName}");
            Console.WriteLine($"Email: {user.Email}");
        }
        static void UpdateProfile(User user, UserService userService)
        {
            try
            {
                Console.Write("New Username: ");
                string newUsername = Console.ReadLine();
                Console.Write("New Password: ");
                string newPassword = Console.ReadLine();
                Console.Write("New Email: ");
                string newEmail = Console.ReadLine();
                userService.UpdateProfile(user, newUsername, newPassword, newEmail);
                Console.WriteLine("Profile updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Correctly!");
            }
        }
        static void AdminPanel(AdminService adminService, Inventory inventory)
        {
            try
            {
                Console.WriteLine("Admin Panel");
                Console.WriteLine("Login:");

                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                Admin admin = adminService.Login(username, password);
                if (admin != null)
                {
                    Console.WriteLine("Login successful!");
                    AdminActions(inventory);
                }
                else
                {
                    Console.WriteLine("Invalid credentials!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Correctly!");
            }
        }
        static void AdminActions(Inventory inventory)
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.WriteLine("1. Manage Stock");
                    Console.WriteLine("2. Manage Categories");
                    Console.WriteLine("3. View Reports");
                    Console.WriteLine("4. View Statistics");
                    Console.WriteLine("5. Logout");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            ManageStock(inventory);
                            break;
                        case 2:
                            ManageCategories(inventory);
                            break;
                        case 3:
                            inventory.GenerateReports();
                            break;
                        case 4:
                            inventory.DisplayStatistics();
                            break;
                        case 5:
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please Enter Correctly!");
                }
            }
        }
        static void ManageStock(Inventory inventory)
        {
            try
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Remove Product");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Product Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Stock: ");
                    int stock = int.Parse(Console.ReadLine());
                    Console.Write("Category: ");
                    string category = Console.ReadLine();
                    inventory.AddProduct(new Product { ProductId = inventory.Products.Count() + 1, ProductName = name, Price = price, Stock = stock, Category = category, InitialStock = stock });
                    Console.WriteLine("Product added successfully!");
                }
                else if (choice == 2)
                {
                    Console.Write("Product ID: ");
                    int productId = int.Parse(Console.ReadLine());
                    var product = inventory.Products.FirstOrDefault(p => p.ProductId == productId);
                    if (product != null)
                    {
                        Console.Write("New Product Name: ");
                        string name = Console.ReadLine();
                        Console.Write("New Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());
                        Console.Write("New Stock: ");
                        int stock = int.Parse(Console.ReadLine());
                        Console.Write("New Category: ");
                        string category = Console.ReadLine();
                        product.ProductName = name;
                        product.Price = price;
                        product.InitialStock = product.InitialStock + (stock - product.Stock);
                        product.Stock = stock;
                        product.Category = category;
                        inventory.UpdateProduct(product);
                        Console.WriteLine("Product updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Product ID: ");
                    int productId = int.Parse(Console.ReadLine());
                    inventory.RemoveProduct(productId);
                    Console.WriteLine("Product removed successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Correctly!");
            }

        }
        static void ManageCategories(Inventory inventory)
        {
            try
            {
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Update Category");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Category Name: ");
                    string categoryName = Console.ReadLine();
                    var newCategory = new Product { Category = categoryName };
                    inventory.Products.Add(newCategory);
                    Console.WriteLine("Category added successfully!");
                }
                else if (choice == 2)
                {
                    Console.Write("Old Category Name: ");
                    string oldCategory = Console.ReadLine();
                    var products = inventory.Products.Where(p => p.Category == oldCategory).ToList();
                    if (products.Any())
                    {
                        Console.Write("New Category Name: ");
                        string newCategory = Console.ReadLine();
                        foreach (var product in products)
                        {
                            product.Category = newCategory;
                        }
                        Console.WriteLine("Category updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Category not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Correctly!");
            }

        }

    }
}
