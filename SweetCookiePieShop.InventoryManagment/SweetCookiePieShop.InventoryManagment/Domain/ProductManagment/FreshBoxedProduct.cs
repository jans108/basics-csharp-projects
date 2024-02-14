using SweetCookiePieShop.InventoryManagment.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCookiePieShop.InventoryManagment.Domain.ProductManagment
{
    public class FreshBoxedProduct : BoxedProduct
    {
        public FreshBoxedProduct(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock, int amountPerBox) : base(id, name, description, price, maxAmountInStock, amountPerBox)
        {
        }
    }
}
