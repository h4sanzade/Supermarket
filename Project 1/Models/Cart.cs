using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalPrice { get { return Products.Sum(p => p.Price); } }

        public void AddProduct(Product product)
        {
            if (product.Stock > 0)
            {
                Products.Add(product);
                product.Stock--;
            }
        }

        public void RemoveProduct(int productId)
        {
            if (Products[productId - 1] != null)
            {
                Products[productId - 1].Stock++;
                Products.Remove(Products[productId - 1]);
            }
        }

        public decimal Checkout(decimal payment, UserShoppingHistoryManager historyManager)
        {
            if (Products.Count == 0)
            {
                return -2;
            }
            else if (payment >= TotalPrice)
            {
                decimal change = payment - TotalPrice;
                historyManager.AddToHistory(Products, TotalPrice);
                Products.Clear();

                return change;
            }
            return -1;
        }
    }

}
