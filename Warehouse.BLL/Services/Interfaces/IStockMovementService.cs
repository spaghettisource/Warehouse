using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.BLL.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WarehouseManagement.Domain.Entities;

    public interface IStockMovementService
    {
        Task<IEnumerable<StockMovement>> GetStockMovementsByWarehouseAsync(int warehouseId);
        Task AddStockMovementAsync(StockMovement movement);
        Task<double> GetCurrentStockLevelAsync(int warehouseId);
        Task<double> GetFreeStockSpaceAsync(int warehouseId);
        Task<IEnumerable<StockMovement>> GetAllStockMovementsAsync();
    }
}
