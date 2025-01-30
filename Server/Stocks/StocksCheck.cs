using Application.Common.Events;
using Application.NotifyRule.CheckStock;
using Infrastructure.Events;
using Microsoft.AspNetCore.Mvc;
using Server.Contracts;

namespace Server.Stocks;

public class StocksCheck : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/v1/stock/check",
                async (IEventDispatcher eventDispatcher,
                    CancellationToken cancellationToken) =>
                {
                    await eventDispatcher.DispatchAsync(new CheckStockEvent(), cancellationToken);
                })
            .WithTags("Stocks");
    }
}