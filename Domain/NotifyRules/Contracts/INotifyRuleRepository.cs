using Domain.NotifyRules.Entities;

namespace Domain.NotifyRules.Contracts;

public interface INotifyRuleRepository
{
    public Task<List<NotifyRule>> GetAllAsync(CancellationToken cancellationToken);
}