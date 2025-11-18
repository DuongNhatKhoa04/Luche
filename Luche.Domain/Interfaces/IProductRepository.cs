using Luche.Domain.Entities;

namespace Luche.Domain.Interfaces
{
    public interface IProductRepository
    {
        public Task<int> AddProductAsync(Product product);
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task UpdateProductAsync(Product product);
        public Task<bool> DeleteProductAsync(int id);
    }
}
