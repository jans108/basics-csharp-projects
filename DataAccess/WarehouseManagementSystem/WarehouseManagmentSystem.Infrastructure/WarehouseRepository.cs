using WarehouseManagementSystem;

namespace WarehouseManagmentSystem.Infrastructure;

public class WarehouseRepository : GenericRepository<Warehouse>
{
    public WarehouseRepository(WarehouseContext context) : base(context)
    {
    }
}
