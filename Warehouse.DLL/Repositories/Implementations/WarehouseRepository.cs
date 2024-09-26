using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.DAL.Context;
using WarehouseManagement.DAL.Repositories.Interfaces;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.DAL.Repositories.Implementations
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AppDbContext _context;

        public WarehouseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses
                .Include(w => w.StockMovements)
                .ToListAsync();
        }

        public async Task<Domain.Entities.Warehouse> GetByIdAsync(int warehouseId)
        {
            return await _context.Warehouses
                .Include(w => w.StockMovements)
                .FirstOrDefaultAsync(w => w.WarehouseID == warehouseId);
        }

        public async Task<Domain.Entities.Warehouse> GetByNameAsync(string warehouseName)
        {
            return await _context.Warehouses
                .Include(w => w.StockMovements)
                .FirstOrDefaultAsync(w => w.WarehouseName == warehouseName);
        }

        public async Task AddAsync(Domain.Entities.Warehouse warehouse)
        {
            await _context.Warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();
        }

    }
}
