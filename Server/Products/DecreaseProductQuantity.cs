using Application.Product;
using Domain.Products.Services;
using Microsoft.AspNetCore.Mvc;
using Server.Contracts;

namespace Server.Products;

public class DecreaseProductQuantity : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/product/{productId}/decrease-stock/{amount}",
                async (
                        [FromRoute] int productId,
                        [FromRoute] int amount,
                        IProductService productService,
                        CancellationToken cancellationToken) =>
                    await productService.DecreaseStock(productId, amount, cancellationToken))
            .WithTags("Products");
    }
}