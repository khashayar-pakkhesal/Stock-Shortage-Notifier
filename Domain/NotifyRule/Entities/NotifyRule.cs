using Domain.Common.ValueObjects;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.NotifyRule.Entities;

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

    public void Validate(Quantity amount)
    {
        if (ViableQuantity != amount)
            throw new Exception($"ViableQuantity is not equal to amount by Rule {Name}");
    }
}