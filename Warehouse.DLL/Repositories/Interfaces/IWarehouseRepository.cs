using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.DAL.Repositories.Interfaces
{
    public interface IWarehouseRepository
    {
        Task AddAsync(WarehouseManagement.Domain.Entities.Warehouse warehouse);
        Task<IEnumerable<Domain.Entities.Warehouse>> GetAllAsync();
        Task<Domain.Entities.Warehouse> GetByIdAsync(int warehouseId);
        Task<Domain.Entities.Warehouse> GetByNameAsync(string warehouseName);
    }
}
