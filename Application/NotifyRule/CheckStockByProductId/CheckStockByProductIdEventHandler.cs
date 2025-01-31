using Application.Common.Events;
using Domain.Notifications;
using Domain.NotifyRules.Contracts;
using Domain.Products.Contracts;

namespace Application.NotifyRule.CheckStockByProductId;

public class CheckStockByProductIdEventHandler(
    INotifyRuleRepository notifyRuleRepository,
    IProductRepository productRepository,
    INotificationService notificationService) : IEventHandler<CheckStockByProductIdEvent>
{
    public async Task HandleEvent(CheckStockByProductIdEvent publishedEvent,
        CancellationToken cancellationToken = default)
    {
        var rules = await notifyRuleRepository.GetAllAsync(cancellationToken);
        var product = await productRepository.GetByIdAsync(publishedEvent.ProductId, cancellationToken);

        foreach (var rule in rules)
        {
            if (rule.IsSatisfied(product.Quantity))
            {
                await notificationService.SendAsync(
                    $"Rule({rule.Name}) We have enough of {product.Name} there is {product.Quantity.Value} in stock");
                continue;
            }

            await notificationService.SendAsync(
                $"Rule({rule.Name}) We are running low on {product.Name} there is only {product.Quantity.Value} left");
        }
    }
}