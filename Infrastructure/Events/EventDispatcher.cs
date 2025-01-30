using Application.Common.Events;
using Application.NotifyRule.CheckStock;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Events;

public class EventDispatcher(IServiceProvider serviceProvider) : IEventDispatcher
{
    public async Task DispatchAsync<TEvent>(TEvent toPublishEvent, CancellationToken cancellationToken = default) where TEvent : IEvent 
    {
        var handlers = serviceProvider.GetServices<IEventHandler<TEvent>>();

        foreach (var handler in handlers)
        {
            await handler.HandleEvent(toPublishEvent, cancellationToken);
        }
    }
}