using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.BLL.Services.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Domain.Entities.Warehouse>> GetAllWarehousesAsync();
        Task<Domain.Entities.Warehouse> GetWarehouseByIdAsync(int warehouseId);
        Task AddWarehouseAsync(Domain.Entities.Warehouse warehouse);
        Task<double> GetCurrentStockLevelAsync(int warehouseId);
        Task<double> GetFreeStockSpaceAsync(int warehouseId);
    }
}
