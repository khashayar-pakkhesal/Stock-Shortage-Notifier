using Domain.NotifyRule.Contracts;
using Domain.NotifyRule.Models;

namespace Infrastructure.Persistence.Repositories;

public class NotifyRuleRepository : INotifyRuleRepository
{
    public List<NotifyRule> GetAll()
    {
        throw new NotImplementedException();
    }
}