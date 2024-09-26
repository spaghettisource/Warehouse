using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
    }
}