using Domain.Common.ValueObjects;
using Domain.Entities;
using Domain.Products.Entities;

namespace Domain.NotifyRules.Entities;

public class NotifyRule : Entity
{
    private NotifyRule()
    {
    }

    public NotifyRule(string name, Quantity viableQuantity)
    {
        Name = name;
        ViableQuantity = viableQuantity;
        CreationDateTime = DateTime.Now;
    }

    public string Name { get; set; }
    public Quantity ViableQuantity { get; set; }

    public bool IsSatisfied(Quantity amount)
    {
        return ViableQuantity.Value <= amount.Value;
    }
}