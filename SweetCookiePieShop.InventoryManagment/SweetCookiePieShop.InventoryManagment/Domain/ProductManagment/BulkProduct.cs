using SweetCookiePieShop.InventoryManagment.Domain.Contracts;
using SweetCookiePieShop.InventoryManagment.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCookiePieShop.InventoryManagment.Domain.ProductManagment
{
    public class BulkProduct : Product, ISaveable
    {
        public BulkProduct(int id, string name, string? description, Price price, int maxAmountInStock) : base(id, name, description, price, UnitType.PerKg, maxAmountInStock)
        {
        }

        public override void IncreaseStock()
        {
            AmountInStock++;
        }
        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)Price.Currency};{(int)UnitType};3;";
        }
    }


}
