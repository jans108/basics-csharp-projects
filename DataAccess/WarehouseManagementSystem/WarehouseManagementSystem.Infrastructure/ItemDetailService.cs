using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Infrastructure;


public class ItemDetailService
{
    private static ConnectionMultiplexer connection;
    private IDatabase database;
    public ItemDetailService()
    {
        connection =
            ConnectionMultiplexer.Connect("sample connection");

        database = connection.GetDatabase();

    }
        public string GetDetailsFor(string itemId)
        {
            var details = database.StringGet(itemId);

            if(details.HasValue)
            {
                return details;
            }
            var loadedDetails =
                $"Item details {DateTimeOffset.UtcNow.ToUnixTimeSeconds}";

            database.StringSet(itemId, loadedDetails);
            return loadedDetails;
        }
    }
}
