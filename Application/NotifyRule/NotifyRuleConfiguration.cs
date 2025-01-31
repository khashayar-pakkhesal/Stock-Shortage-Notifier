using Application.Common.Events;
using Application.NotifyRule.CheckStock;
using Application.NotifyRule.CheckStockByProductId;
using Microsoft.Extensions.DependencyInjection;

namespace Application.NotifyRule;

public static class NotifyRuleConfiguration
{
    public static void AddNotifyRule(this IServiceCollection services)
    {        
        services.AddTransient<IEventHandler<CheckStockEvent>, CheckStockEventHandler>();
        services.AddTransient<IEventHandler<CheckStockByProductIdEvent>, CheckStockByProductIdEventHandler>();
    }
}