using Domain.Products.Contracts;
using Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepository(StockShortageDbContext dbContext) : IProductRepository
{
    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Products.ToListAsync(cancellationToken);
    }

    public async Task<Product> GetByIdAsync(int productId, CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .Where(x => x.Id == productId)
            .FirstAsync(cancellationToken);
    }
}