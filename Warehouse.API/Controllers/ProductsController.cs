using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.BLL.Services.Interfaces;

namespace WarehouseManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService; // Assume you have a service layer

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWarehousesAsync()
        {
            var productEntities = await _productService.GetAllProductsAsync();

            // Manually map the entities to DTOs
            var productDtos = productEntities.Select(product => new ProductDto
            {
             ProductID = product.ProductID,
             ProductName = product.ProductName,
                SizePerUnit = product.SizePerUnit,
                IsHazardous = product.IsHazardous
            }).ToList();

            return Ok(productDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map DTO to Domain Model (you can use AutoMapper for this)
            var product = new Product
            {
                ProductName = productDto.ProductName,
                SizePerUnit = (float)productDto.SizePerUnit,
                IsHazardous = productDto.IsHazardous,
                StockMovements = productDto.StockMovements != null
                    ? productDto.StockMovements.ConvertAll(sm => new StockMovement
                    {
                        MovementID = sm.MovementID,
                        WarehouseID = sm.WarehouseID,
                        ProductID = sm.ProductID,
                        Amount = sm.Amount,
                        Date = sm.Date,
                        IsImport = sm.IsImport,
                        
                    })
                    : new List<StockMovement>()
            };

            // Call your service to handle the creation
            var createdProduct = await _productService.AddProductAsync(product);

            return Ok(createdProduct);
        }

        
    }
}
