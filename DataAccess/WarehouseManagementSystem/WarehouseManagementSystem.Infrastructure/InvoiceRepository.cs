using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Infrastructure;

public class InvoiceRepository
{
    public async Task Add(Invoice invoice)
    {
        using var client = new CosmosClient(
            accountEndpoint: "https://csharp-data-acess.com"
            authKeyOrResourceToken: "f4mkemfkl903KWfawld"
            );

        Database database =
            await client.CreateDatabaseIfNotExistsAsync("WarehouseManagementSystem");

        Container container =
            await database.CreateContainerIfNotExistsAsync(
                id: "invoices",
                partitionKeyPath: "/customerId",
                throughput: 400
                );

        await container.UpsertItemAsync(invoice);
    }
}
