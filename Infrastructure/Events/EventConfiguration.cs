using Application.Common.Events;
using Application.NotifyRule.CheckStock;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Events;

public static class EventConfiguration
{
    public static void AddEventHandlers(this IServiceCollection services)
    {        
        services.AddTransient<IEventDispatcher, EventDispatcher>();
        
        services.AddTransient<IEventHandler<CheckStockEvent>, CheckStockEventHandler>();
    }
}