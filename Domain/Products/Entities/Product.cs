using Domain.Common.ValueObjects;
using Domain.Entities;

namespace Domain.Products.Entities;

public class Product : Entity
{
    private Product()
    {
    }

    public Product(string name, Quantity quantity)
    {
        Name = name;
        Quantity = quantity;
        CreationDateTime = DateTime.Now;
    }

    public string Name { get; set; }
    public Quantity Quantity { get; set; }
}