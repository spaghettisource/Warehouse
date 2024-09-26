using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.BLL.Services.Interfaces;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.DAL.Repositories.Interfaces;

namespace WarehouseManagement.BLL.Services
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _stockMovementRepository;

        public StockMovementService(IStockMovementRepository stockMovementRepository)
        {
            _stockMovementRepository = stockMovementRepository;
        }

        public async Task AddStockMovementAsync(StockMovement stockMovement)
        {
            await _stockMovementRepository.AddAsync(stockMovement);
        }

        // Fetch all stock movements
        public async Task<IEnumerable<StockMovement>> GetAllStockMovementsAsync()
        {
            return await _stockMovementRepository.GetAllAsync();
        }

        public Task<double> GetCurrentStockLevelAsync(int warehouseId)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetFreeStockSpaceAsync(int warehouseId)
        {
            throw new NotImplementedException();
        }

        // Fetch stock movements by warehouse
        public async Task<IEnumerable<StockMovement>> GetStockMovementsByWarehouseAsync(int warehouseId)
        {
            return await _stockMovementRepository.GetByWarehouseAsync(warehouseId);
        }
    }
}
