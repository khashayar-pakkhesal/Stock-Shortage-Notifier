using Domain.Products.Contracts;
using Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepository(StockShortageDbContext dbContext) : IProductRepository
{
    public async Task<List<Product>> GetAllAsync()
    {
        return await dbContext.Products.ToListAsync();
    }
}