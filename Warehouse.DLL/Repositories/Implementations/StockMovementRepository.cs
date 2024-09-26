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
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly AppDbContext _context;

        public StockMovementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockMovement>> GetAllAsync()
        {
            return await _context.StockMovements
                .Include(sm => sm.Product)    // Include related Product entity if needed
                .Include(sm => sm.Warehouse)  // Include related Warehouse entity if needed
                .ToListAsync();
        }

        // Fetch stock movements by warehouse ID
        public async Task<IEnumerable<StockMovement>> GetByWarehouseAsync(int warehouseId)
        {
            return await _context.StockMovements
                .Where(sm => sm.WarehouseID == warehouseId)
                .Include(sm => sm.Product)    // Include related Product entity if needed
                .Include(sm => sm.Warehouse)  // Include related Warehouse entity if needed
                .ToListAsync();
        }

        public async Task AddAsync(StockMovement movement)
        {
            await _context.StockMovements.AddAsync(movement);
            await _context.SaveChangesAsync();
        }

    }
}
