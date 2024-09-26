using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.DAL.Interfaces;
using WarehouseManagement.DAL.Repositories.Interfaces;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.BLL.Services.Interfaces
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IProductRepository _productRepository;

        public WarehouseService(
            IWarehouseRepository warehouseRepository,
            IStockMovementRepository stockMovementRepository,
            IProductRepository productRepository)
        {
            _warehouseRepository = warehouseRepository;
            _stockMovementRepository = stockMovementRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Warehouse>> GetAllWarehousesAsync()
        {
            return await _warehouseRepository.GetAllAsync();
        }

        public async Task<Domain.Entities.Warehouse> GetWarehouseByIdAsync(int warehouseId)
        {
            return await _warehouseRepository.GetByIdAsync(warehouseId);
        }

        public async Task AddWarehouseAsync(Domain.Entities.Warehouse warehouse)
        {
            // Validate warehouse data if necessary
            // For example, check for unique warehouse name
            var existingWarehouse = await _warehouseRepository.GetByNameAsync(warehouse.WarehouseName);
            if (existingWarehouse != null)
            {
                throw new InvalidOperationException("A warehouse with the same name already exists.");
            }
        }

        public async Task<double> GetCurrentStockLevelAsync(int warehouseId)
        {
            var stockMovements = await _stockMovementRepository.GetByWarehouseAsync(warehouseId);
            double currentStock = 0;

            foreach (var movement in stockMovements)
            {
                var product = await _productRepository.GetByIdAsync(movement.ProductID);
                double movementVolume = product.SizePerUnit * movement.Amount;
                currentStock += movement.IsImport ? movementVolume : -movementVolume;
            }

            return currentStock;
        }

        public async Task<double> GetFreeStockSpaceAsync(int warehouseId)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(warehouseId);
            if (warehouse == null)
            {
                throw new InvalidOperationException("Warehouse does not exist.");
            }

            var currentStock = await GetCurrentStockLevelAsync(warehouseId);
            return warehouse.MaxStockAmount - currentStock;
        }
    }
}
