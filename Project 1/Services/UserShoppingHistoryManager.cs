using Project_1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class UserShoppingHistoryManager
{
    private string historyFilePath;
    private List<ShoppingHistoryEntry> shoppingHistory;

    public UserShoppingHistoryManager(string username)
    {
        
        // Istifadecinin alisveris gecmisini saxliyacaq fayl
        historyFilePath = $"{username}_shopping_history.json";

        // Eger fayl varsa, kecmisi yukle, yoxdursa yeni bir list yarat
        if (File.Exists(historyFilePath))
        {
            string json = File.ReadAllText(historyFilePath);
            shoppingHistory = JsonSerializer.Deserialize<List<ShoppingHistoryEntry>>(json);
        }
        else
        {
            shoppingHistory = new List<ShoppingHistoryEntry>();
        }
    }

    public void AddToHistory(List<Product> purchasedProducts, decimal totalAmount)
    {
        // Yeni bir alisveris kecmisi yaratmaq
        var productsList = purchasedProducts.Select(p => $"{p.ProductName} - {p.Price:C}").ToList();
        var entry = new ShoppingHistoryEntry(DateTime.Now, productsList, totalAmount);

        // kohne alisveris kecmisine yenisini yarat
        shoppingHistory.Add(entry);

        // Yenilenmis alisveris kecmisini yenile
        SaveHistoryToFile();
    }



    public void DisplayHistory()
    {
        foreach (var entry in shoppingHistory)
        {
            Console.WriteLine($"Purchase Date: {entry.PurchaseDate}");
            Console.WriteLine("Purchased Products:");
            foreach (var product in entry.PurchasedProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine($"Total Amount: {entry.TotalAmount:C}");
            Console.WriteLine();
        }
    }

    private void SaveHistoryToFile()
    {
        string json = JsonSerializer.Serialize(shoppingHistory);
        File.WriteAllText(historyFilePath, json);
    }
}
