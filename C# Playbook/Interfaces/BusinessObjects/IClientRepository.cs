using Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public interface IClientRepository
    {
        GardenClient GetClientFromId(int clientId);
        bool PersistCart(GardenClient client);
    }
}
