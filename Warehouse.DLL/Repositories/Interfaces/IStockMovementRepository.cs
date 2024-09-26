using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.DAL.Repositories.Interfaces
{
    public interface IStockMovementRepository
    {
        Task AddAsync(StockMovement stockMovement);
        Task<IEnumerable<StockMovement>> GetAllAsync();
        Task<IEnumerable<StockMovement>> GetByWarehouseAsync(int warehouseId);
    }
}
