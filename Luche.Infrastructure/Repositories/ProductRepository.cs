using Luche.Domain.Entities;
using Luche.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Luche.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext m_context;

    public ProductRepository(ApplicationDbContext context)
    {
        m_context = context;
    }

    public async Task<int> AddProductAsync(Product product)
    {
        await m_context.Products.AddAsync(product);
        await m_context.SaveChangesAsync();

        return product.Id;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await m_context.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await m_context.Products.FindAsync(id);
    }

    public async Task UpdateProductAsync(Product product)
    {
        m_context.Products.Update(product);
        await m_context.SaveChangesAsync();
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = m_context.Products.Find(id);
        if (product == null) return false;

        m_context.Products.Remove(product);
        await m_context.SaveChangesAsync();
        return true;
    }
}