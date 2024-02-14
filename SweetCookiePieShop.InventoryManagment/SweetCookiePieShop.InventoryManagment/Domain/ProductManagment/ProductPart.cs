using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SweetCookiePieShop.InventoryManagment.Domain.ProductManagment
{
    public partial class Product
    {
        public static int StockThreshold = 5;

        public static void ChangeStockThreshold(int newStockThreshold)
        {
            if (newStockThreshold > 0)
                StockThreshold = newStockThreshold;
        }
        public void UpdateLowStock()
        {
            
            if (AmountInStock < StockThreshold)
            {
                IsBelowStockTreshold = true;
            }
            else
            {
                IsBelowStockTreshold = false;
            }
        }
        protected static void Log(string message)
        {
            //this could be written to a file
            Console.WriteLine(message);
        }
        protected string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }
    }
}
