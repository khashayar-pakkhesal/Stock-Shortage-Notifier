using Domain.NotifyRules.Contracts;
using Domain.NotifyRules.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class NotifyRuleRepository(StockShortageDbContext dbContext) : INotifyRuleRepository
{
    public async Task<List<NotifyRule>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.NotifyRules.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(NotifyRule product, CancellationToken cancellationToken)
    {
        await dbContext.NotifyRules.AddAsync(product, cancellationToken);
    }
}