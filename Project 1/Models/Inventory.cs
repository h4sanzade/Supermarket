using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class Inventory
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public string productsFilePath = "products.json";
        public string statisticsFilePath = "statistics.json";
        private decimal totalSales;
        private Dictionary<string, decimal> categorySales;
        private Dictionary<string, int> categoryInitialStock;
        private Dictionary<string, int> categoryCurrentStock;
        public Inventory()
        {
            LoadProducts();
            LoadStatistics();
        }
        private void LoadProducts()
        {
            if (File.Exists(productsFilePath))
            {
                string json = File.ReadAllText(productsFilePath);
                Products = JsonSerializer.Deserialize<List<Product>>(json);
            }
            else
            {
                Products = new List<Product>();
            }
        }

        private void SaveProducts()
        {
            string json = JsonSerializer.Serialize(Products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(productsFilePath, json);
        }
        private void LoadStatistics()
        {
            if (File.Exists(statisticsFilePath))
            {
                string json = File.ReadAllText(statisticsFilePath);
                var statisticsData = JsonSerializer.Deserialize<StatisticsData>(json);

                totalSales = statisticsData.TotalSales;
                categorySales = statisticsData.CategorySales;
                categoryInitialStock = statisticsData.CategoryInitialStock;
                categoryCurrentStock = statisticsData.CategoryCurrentStock;
            }
            else
            {
                totalSales = 0;
                categorySales = new Dictionary<string, decimal>();
                categoryInitialStock = new Dictionary<string, int>();
                categoryCurrentStock = new Dictionary<string, int>();
            }
        }

        private void SaveStatistics()
        {
            var statisticsData = new StatisticsData
            {
                TotalSales = totalSales,
                CategorySales = categorySales,
                CategoryInitialStock = categoryInitialStock,
                CategoryCurrentStock = categoryCurrentStock
            };

            string json = JsonSerializer.Serialize(statisticsData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(statisticsFilePath, json);
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
            SaveProducts();
            SaveStatistics();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Price = product.Price;


                existingProduct.Stock = product.Stock;

                existingProduct.InitialStock = product.InitialStock;
                existingProduct.Category = product.Category;
                SaveProducts();
                SaveStatistics();

            }
        }

        public void RemoveProduct(int productId)
        {
            var product = Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                Products.Remove(product);
                SaveProducts();
                SaveStatistics();
            }
        }

        public void GenerateReports()
        {
            Console.WriteLine("Product Reports:");
            foreach (var product in Products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Product: {product.ProductName}, Stock: {product.Stock}, Price: {product.Price}");
            }
        }

        public void DisplayStatistics()
        {

            decimal totalSales = 0;

            var categorySales = new Dictionary<string, decimal>();
            var categoryInitialStock = new Dictionary<string, int>();
            var categoryCurrentStock = new Dictionary<string, int>();

            foreach (var product in Products)
            {
                int soldQuantity = product.InitialStock - product.Stock;

                decimal productSales = product.Price * soldQuantity;
                totalSales += productSales;

                if (!categorySales.ContainsKey(product.Category))
                {
                    categorySales[product.Category] = 0;
                    categoryInitialStock[product.Category] = 0;
                    categoryCurrentStock[product.Category] = 0;
                }

                categorySales[product.Category] += productSales;
                categoryInitialStock[product.Category] += product.InitialStock;
                categoryCurrentStock[product.Category] += product.Stock;
            }

            Console.WriteLine($"Total Sales: {totalSales}");

            foreach (var category in categorySales)
            {
                decimal percentageSales = category.Value / totalSales * 100;
                int totalSold = categoryInitialStock[category.Key] - categoryCurrentStock[category.Key];
                decimal percentageStockSold = (decimal)totalSold / categoryInitialStock[category.Key] * 100;

                Console.WriteLine($"Category: {category.Key}, Total Sales: {category.Value}, Percentage Sales: {percentageSales:F2}%, Percentage Stock Sold: {percentageStockSold:F2}%");
            }
            var statisticsData = new StatisticsData
            {
                TotalSales = totalSales,
                CategorySales = categorySales,
                CategoryInitialStock = categoryInitialStock,
                CategoryCurrentStock = categoryCurrentStock
            };

            string json = JsonSerializer.Serialize(statisticsData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(statisticsFilePath, json);
        }
    }
}


