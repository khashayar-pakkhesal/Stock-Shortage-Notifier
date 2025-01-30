using Application.Common.Events;
using Domain.NotifyRule.Contracts;
using Domain.Product.Contracts;

namespace Application.NotifyRule.CheckStock;

public class CheckStockEventHandler : IEventHandler<CheckStockEvent>
{
    public Task HandleEvent(CheckStockEvent publishedEvent, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}