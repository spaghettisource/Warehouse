using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WarehouseManagement.BLL.Services.Interfaces;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWarehousesAsync()
        {
            var warehouseEntities = await _warehouseService.GetAllWarehousesAsync();

            // Manually map the entities to DTOs
            var warehouseDtos = warehouseEntities.Select(warehouse => new WarehouseDto
            {
                WarehouseID = warehouse.WarehouseID,
                WarehouseName = warehouse.WarehouseName,
                MaxStockAmount = (int)warehouse.MaxStockAmount,
                IsHazardousOnly = warehouse.IsHazardousOnly,
                StockMovements = warehouse.StockMovements.Select(sm => sm.MovementID.ToString()).ToList()  // Assuming you want to return just MovementIDs
            }).ToList();

            return Ok(warehouseDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouse(int id)
        {
            var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> AddWarehouse([FromBody] Domain.Entities.Warehouse warehouse)
        {
            try
            {
                await _warehouseService.AddWarehouseAsync(warehouse);
                return CreatedAtAction(nameof(GetWarehouse), new { id = warehouse.WarehouseID }, warehouse);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
