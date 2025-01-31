using Domain.Common.ValueObjects;
using Domain.Products.Entities;
using Xunit;

namespace Domain.Tests;


public class ProductTests
{
    [Fact]
    public void Constructor_ShouldCreateProduct_WithValidNameAndQuantity()
    {
        var productName = "Test Product";
        var initialQuantity = Quantity.Create(10);

        var product = new Product(productName, initialQuantity);

        Assert.Equal(productName, product.Name);
        Assert.Equal(initialQuantity.Value, product.Quantity.Value);
    }

    [Fact]
    public void IncreaseQuantity_ShouldIncreaseProductQuantity()
    {
        var product = new Product("Test Product", Quantity.Create(10));
        var increaseAmount = Quantity.Create(5);

        product.IncreaseQuantity(increaseAmount);

        Assert.Equal(15, product.Quantity.Value);
    }

    [Fact]
    public void DecreaseQuantity_ShouldDecreaseProductQuantity()
    {
        var product = new Product("Test Product", Quantity.Create(10));
        var decreaseAmount = Quantity.Create(5);

        product.DecreaseQuantity(decreaseAmount);

        Assert.Equal(5, product.Quantity.Value);
    }

    [Fact]
    public void DecreaseQuantity_ShouldNotAllowNegativeQuantity()
    {
        var product = new Product("Test Product", Quantity.Create(10));
        var decreaseAmount = Quantity.Create(15);  // Trying to decrease more than available

        Assert.Throws<ArgumentException>(() => product.DecreaseQuantity(decreaseAmount));
    }
}