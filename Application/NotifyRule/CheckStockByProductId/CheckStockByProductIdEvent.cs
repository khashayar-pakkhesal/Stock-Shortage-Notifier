using Application.Common.Events;

namespace Application.NotifyRule.CheckStockByProductId;

public class CheckStockByProductIdEvent(int productId) : IEvent
{
    public int ProductId { get; set; } = productId;
}