namespace Domain.NotifyRule.Contracts;
using NotifyRule = Entities.NotifyRule;

public interface INotifyRuleRepository
{
    public List<NotifyRule> GetAll();
}