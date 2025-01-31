using Application.Common.Events;
using Domain.Notifications;
using Domain.NotifyRules.Contracts;
using Domain.Products.Contracts;

namespace Application.NotifyRule.CheckStock;

public class CheckStockEventHandler(
    INotifyRuleRepository notifyRuleRepository,
    IProductRepository productRepository,
    INotificationService notificationService)
    : IEventHandler<CheckStockEvent>
{
    public async Task HandleEvent(CheckStockEvent publishedEvent, CancellationToken cancellationToken = default)
    {
        var rules = await notifyRuleRepository.GetAllAsync();
        var products = await productRepository.GetAllAsync();

        foreach (var rule in rules)
        {
            foreach (var product in products)
            {
                if (rule.IsSatisfied(product.Quantity))
                    continue;

                await notificationService.SendAsync(
                    $"Rule({rule.Name}) We are running low on {product.Name} there is only {product.Quantity.Value} left");
            }
        }
    }
}