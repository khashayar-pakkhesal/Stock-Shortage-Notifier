using Domain.Common.ValueObjects;
using Domain.NotifyRules.Entities;
using Xunit;

namespace Domain.Tests;


public class NotifyRuleTests
{
    [Fact]
    public void IsSatisfied_QuantityGreaterThanViableQuantity_ReturnsTrue()
    {
        var viableQuantity = Quantity.Create(5);
        var rule = new NotifyRule("Test Rule", viableQuantity);

        var testQuantity = Quantity.Create(10);

        var result = rule.IsSatisfied(testQuantity);

        Assert.True(result);
    }

    [Fact]
    public void IsSatisfied_QuantityEqualToViableQuantity_ReturnsTrue()
    {
        var viableQuantity = Quantity.Create(5);
        var rule = new NotifyRule("Test Rule", viableQuantity);

        var testQuantity = Quantity.Create(5);

        var result = rule.IsSatisfied(testQuantity);

        Assert.True(result);
    }

    [Fact]
    public void IsSatisfied_QuantityLessThanViableQuantity_ReturnsFalse()
    {
        var viableQuantity = Quantity.Create(5);
        var rule = new NotifyRule("Test Rule", viableQuantity);

        var testQuantity = Quantity.Create(3);

        var result = rule.IsSatisfied(testQuantity);

        Assert.False(result);
    }
}