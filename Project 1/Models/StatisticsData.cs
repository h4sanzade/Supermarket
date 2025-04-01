using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Models
{
    public class StatisticsData
    {
        public decimal TotalSales { get; set; }
        public Dictionary<string, decimal> CategorySales { get; set; }
        public Dictionary<string, int> CategoryInitialStock { get; set; }
        public Dictionary<string, int> CategoryCurrentStock { get; set; }

        public StatisticsData()
        {
            CategorySales = new Dictionary<string, decimal>();
            CategoryInitialStock = new Dictionary<string, int>();
            CategoryCurrentStock = new Dictionary<string, int>();
        }
    }

}
