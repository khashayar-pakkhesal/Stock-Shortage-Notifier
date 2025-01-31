using Application.Common.Events;
using Application.NotifyRule.CheckStockByProductId;
using Domain.Common.ValueObjects;
using Domain.Persistence;
using Domain.Products.Contracts;
using Domain.Products.Services;

namespace Application.Product;

public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IEventDispatcher eventDispatcher) : IProductService
{
    public async Task IncreaseStock(int productId, int quantity, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(productId, cancellationToken);

        product.IncreaseQuantity(Quantity.Create(quantity));

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        await eventDispatcher.DispatchAsync(new CheckStockByProductIdEvent(product.Id), cancellationToken);
    }

    public async Task DecreaseStock(int productId, int quantity, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(productId, cancellationToken);

        product.DecreaseQuantity(Quantity.Create(quantity));

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        await eventDispatcher.DispatchAsync(new CheckStockByProductIdEvent(product.Id), cancellationToken);
    }
}