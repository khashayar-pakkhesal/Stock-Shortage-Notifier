namespace Domain.Products.Services;

public interface IProductService
{
    public Task IncreaseStock(int productId, int quantity, CancellationToken cancellationToken);
    public Task DecreaseStock(int productId, int quantity, CancellationToken cancellationToken);
}