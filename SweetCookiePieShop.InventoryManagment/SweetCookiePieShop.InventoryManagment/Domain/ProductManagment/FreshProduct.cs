﻿using SweetCookiePieShop.InventoryManagment.Domain.Contracts;
using SweetCookiePieShop.InventoryManagment.Domain.General;
using System.Text;


namespace SweetCookiePieShop.InventoryManagment.Domain.ProductManagment
{
    public class FreshProduct : Product, ISaveable
    {
        public DateTime ExpiryDateTime { get; set; }

        public string? StorageInstructions { get; set; }


        public FreshProduct(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) : base(id, name, description, price, unitType, maxAmountInStock)
        {
        }

        public override void IncreaseStock()
        {
            AmountInStock++;
        }

        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)Price.Currency};{(int)UnitType};2;";
        }

        public override string DisplayDetailsFull()
        {
            {
                StringBuilder sb = new();

                sb.Append($"{Id} {Name}  \n{Description}\n{Price}\n{AmountInStock}  item(s) in stock");


                if (IsBelowStockTreshold)
                {
                    sb.Append("\n!!STOCK LOW!!");
                }

                sb.AppendLine("Storage instructions: " + StorageInstructions);

                sb.AppendLine("Expiry date: " + ExpiryDateTime.ToShortDateString());

                return sb.ToString();
            }
        }
        public override object Clone()
        {
            return new FreshProduct(0, this.Name, this.Description, new Price() { ItemPrice = this.Price.ItemPrice, Currency = this.Price.Currency },this.UnitType, this.maxItemsInStock);
        }
    }

    
}
