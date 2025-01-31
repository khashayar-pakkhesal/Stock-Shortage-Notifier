using Domain.Products.Entities;

namespace Domain.Products.Contracts;

public interface IProductRepository
{
    public Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Product> GetByIdAsync(int productId, CancellationToken cancellationToken);

}