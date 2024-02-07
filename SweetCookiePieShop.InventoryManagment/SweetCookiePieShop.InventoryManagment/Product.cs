using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SweetCookiePieShop.InventoryManagment
{
    public class Product
    {
        private int id;
        private string name = string.Empty;
        private string? description;
        private int? price;

        private int maxItemsInStock = 0;

        private UnitType unitType;
        private int amountInStock = 0;
        private bool isBelowStockTreshold = false;

        public void UseProduct(int items)
        {
            if (items <= amountInStock)
            {
                amountInStock -= items;

                UpdateLowStock();

                Log($"Amount in stock updated. Now {amountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. {amountInStock} available but {items} requested. ");
            }
        }
        public void IncreaseStock()
        {
            amountInStock++;
        }

        private void DecreaseStock(int items, string reason)
        {
            if (items <= amountInStock)
            {
                amountInStock -= items;
            }
            else
            {
                amountInStock = 0;
            }

            UpdateLowStock();

            Log(reason);
        }

        public string DisplayDetailsShort()
        {
            return $"{id}. {name} \n{amountInStock} items in stock";
        }

        public string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{id} {name} \n{price}  \n{description}\n{amountInStock}  item(s) in stock");

            if ( isBelowStockTreshold )
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();
        }

        private void UpdateLowStock()
        {
            if (amountInStock < 10)
            {
                isBelowStockTreshold = true;
            }
        }
        private void Log(string message)
        {
            //this could be written to a file
            Console.WriteLine(message);
        }
        private string CreateSimplePorductRepresentation()
        {
            return $"Product {id} ({name})";
        }
    }
}
