using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.BLL.Services.Interfaces;
using WarehouseManagement.Domain.Dtos;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockMovementsController : ControllerBase
    {
        private readonly IStockMovementService _stockMovementService;

        public StockMovementsController(IStockMovementService stockMovementService)
        {
            _stockMovementService = stockMovementService;
        }

        // POST: api/stockmovements/warehouse/{warehouseId}/add
        [HttpPost("warehouse/{warehouseId}/add")]
        public async Task<IActionResult> AddStockMovement(int warehouseId, [FromBody] StockMovementDto stockMovementDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var stockMovement = new StockMovement
                {
                    WarehouseID = stockMovementDto.WarehouseID,
                    ProductID = stockMovementDto.ProductID,
                    Amount = stockMovementDto.Amount,
                    Date = stockMovementDto.Date,
                    IsImport = stockMovementDto.IsImport
                };

                await _stockMovementService.AddStockMovementAsync(stockMovement);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/stockmovements
        // GET: api/stockmovements
        [HttpGet]
        public async Task<IActionResult> GetAllStockMovements()
        {
            try
            {
                // Fetch the StockMovement entities from the service
                var stockMovements = await _stockMovementService.GetAllStockMovementsAsync();

                // Map the entities to DTOs within the controller
                var stockMovementDtos = stockMovements.Select(sm => new StockMovementDto
                {
                    MovementID = sm.MovementID,
                    WarehouseID = sm.WarehouseID,
                    //arehouseName = sm.Warehouse.WarehouseName, // Include the warehouse name
                    ProductID = sm.ProductID,
                    //ProductName = sm.Product.ProductName, // Include the product name
                    Amount = sm.Amount,
                    Date = sm.Date,
                    IsImport = sm.IsImport
                }).ToList();

                return Ok(stockMovementDtos); // Return DTOs to the client
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/stockmovements/warehouse/{warehouseId}
        [HttpGet("warehouse/{warehouseId}")]
        public async Task<IActionResult> GetStockMovementsByWarehouse(int warehouseId)
        {
            try
            {
                // Fetch the StockMovement entities for a specific warehouse
                var stockMovements = await _stockMovementService.GetStockMovementsByWarehouseAsync(warehouseId);

                // Map the entities to DTOs within the controller
                var stockMovementDtos = stockMovements.Select(sm => new StockMovementDto
                {
                    MovementID = sm.MovementID,
                    WarehouseID = sm.WarehouseID,
                    // WarehouseName = sm.Warehouse.WarehouseName, // Include the warehouse name
                    ProductID = sm.ProductID,
                    // ProductName = sm.Product.ProductName, // Include the product name
                    Amount = sm.Amount,
                    Date = sm.Date,
                    IsImport = sm.IsImport
                }).ToList();

                return Ok(stockMovementDtos); // Return DTOs to the client
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
