using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class ShoppingHistoryEntry
    {
        public DateTime PurchaseDate { get; set; }
        public List<string> PurchasedProducts { get; set; }
        public decimal TotalAmount { get; set; }

        public ShoppingHistoryEntry(DateTime purchaseDate, List<string> purchasedProducts, decimal totalAmount)
        {
            PurchaseDate = purchaseDate;
            PurchasedProducts = purchasedProducts;
            TotalAmount = totalAmount;
        }
    }



}
