using Domain.Common.ValueObjects;
using Domain.NotifyRule.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class NotifyRuleTypeConfiguration : IEntityTypeConfiguration<NotifyRule>
{
    public void Configure(EntityTypeBuilder<NotifyRule> builder)
    {
        builder.ToTable(nameof(NotifyRule));
        builder.HasKey(a => a.Id);

        builder.Property(x => x.Name);

        builder.Property(x => x.ViableQuantity)
            .HasColumnName("ViableQuantity")
            .IsRequired()
            .HasConversion(prop => prop.Value,
                value => Quantity.Create(value));
    }
}