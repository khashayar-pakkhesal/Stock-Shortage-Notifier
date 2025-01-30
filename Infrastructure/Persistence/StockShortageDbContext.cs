using Domain.NotifyRule.Models;
using Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class StockShortageDbContext
(DbContextOptions<StockShortageDbContext> options):
DbContext(options), IUnitOfWork
{
    public DbSet<NotifyRule> NotifyRules { get; set; }
}