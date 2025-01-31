using Domain.Products.Services;
using Microsoft.AspNetCore.Mvc;
using Server.Contracts;

namespace Server.Products;

public class IncreaseProductQuantity : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/product/{productId}/increase-stock/{amount}",
               async (
                        [FromRoute] int productId,
                        [FromRoute] int amount,
                        IProductService productService,
                        CancellationToken cancellationToken) =>
                    await productService.IncreaseStock(productId, amount, cancellationToken))
            .WithTags("Products");
    }
}