namespace Domain.NotifyRule.Contracts;
using NotifyRule = Models.NotifyRule;

public interface INotifyRuleRepository
{
    public List<NotifyRule> GetAll();
}