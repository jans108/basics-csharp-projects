using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCookiePieShop.InventoryManagment.Domain.Contracts
{
    public interface ISaveable
    {
        string ConvertToStringForSaving();
    }
}
