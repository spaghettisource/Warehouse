using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.DAL.Interfaces;

namespace WarehouseManagement.BLL.Services.Interfaces
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            // Business logic (e.g., validation) can be added here
            await _productRepository.AddAsync(product);
            return await _productRepository.GetByIdAsync(product.ProductID);
        }

    }
}
