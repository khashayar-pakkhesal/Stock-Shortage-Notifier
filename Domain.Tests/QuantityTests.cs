using Domain.Common.ValueObjects;
using Xunit;

namespace Domain.Tests;

public class QuantityTests
{
    [Fact]
    public void Create_ShouldThrowArgumentException_WhenQuantityIsNegative()
    {
        Assert.Throws<ArgumentException>(() => Quantity.Create(-1));
    }

    [Fact]
    public void Create_ShouldCreateValidQuantity_WhenPositiveValue()
    {
        var quantity = Quantity.Create(10);

        Assert.Equal(10, quantity.Value);
    }

    [Fact]
    public void CompareTo_ShouldReturnZero_WhenQuantitiesAreEqual()
    {
        var quantity1 = Quantity.Create(10);
        var quantity2 = Quantity.Create(10);

        var result = quantity1.CompareTo(quantity2);

        Assert.Equal(0, result);
    }

    [Fact]
    public void CompareTo_ShouldReturnPositive_WhenFirstIsGreater()
    {
        var quantity1 = Quantity.Create(15);
        var quantity2 = Quantity.Create(10);

        var result = quantity1.CompareTo(quantity2);

        Assert.True(result > 0);
    }

    [Fact]
    public void CompareTo_ShouldReturnNegative_WhenFirstIsSmaller()
    {
        var quantity1 = Quantity.Create(5);
        var quantity2 = Quantity.Create(10);

        var result = quantity1.CompareTo(quantity2);

        Assert.True(result < 0);
    }

    [Fact]
    public void OperatorPlus_ShouldReturnCorrectSum()
    {
        var quantity1 = Quantity.Create(10);
        var quantity2 = Quantity.Create(5);

        var result = quantity1 + quantity2;

        Assert.Equal(15, result.Value);
    }

    [Fact]
    public void OperatorMinus_ShouldReturnCorrectDifference()
    {
        var quantity1 = Quantity.Create(10);
        var quantity2 = Quantity.Create(5);

        var result = quantity1 - quantity2;

        Assert.Equal(5, result.Value);
    }
}