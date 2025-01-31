using Domain.Common.ValueObjects;
using Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ProductTypeConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(a => a.Id);

        builder.Property(x => x.Name);

        builder.Property(x => x.Quantity)
            .HasColumnName("Quantity")
            .IsRequired()
            .HasConversion(prop => prop.Value,
                value => Quantity.Create(value));
    }
}