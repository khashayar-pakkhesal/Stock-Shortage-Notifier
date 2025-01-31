using Application.Common.Events;
using Application.NotifyRule.CheckStockByProductId;
using Microsoft.AspNetCore.Mvc;
using Server.Contracts;

namespace Server.Stocks;

public class StocksCheckByProductId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/stock/check/{productId}",
                async ([FromRoute] int productId,
                        IEventDispatcher eventDispatcher,
                        CancellationToken cancellationToken) =>
                    await eventDispatcher.DispatchAsync(new CheckStockByProductIdEvent(productId), cancellationToken))
            .WithTags("Stocks");
    }
}