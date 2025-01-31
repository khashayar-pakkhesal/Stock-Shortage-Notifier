using Domain.NotifyRules.Entities;
using Domain.Persistence;
using Domain.Products.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class StockShortageDbContext(DbContextOptions<StockShortageDbContext> options) :
    DbContext(options), IUnitOfWork
{
    public DbSet<NotifyRule> NotifyRules { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new NotifyRuleTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
    }
}