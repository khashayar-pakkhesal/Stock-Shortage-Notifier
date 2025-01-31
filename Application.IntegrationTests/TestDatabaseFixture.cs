using Domain.Common.ValueObjects;
using Domain.NotifyRules.Contracts;
using Domain.Products.Contracts;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.IntegrationTests;

public class TestDatabaseFixture : IAsyncLifetime
{
    public DbContextOptions<StockShortageDbContext> Options { get; }
    public IProductRepository ProductRepository { get; }
    public INotifyRuleRepository NotifyRuleRepository { get; }
    private readonly StockShortageDbContext _context;


    public TestDatabaseFixture()
    {
        // Setup in-memory database
        Options = new DbContextOptionsBuilder<StockShortageDbContext>()
            .UseInMemoryDatabase("test-stock-shortage-db")
            .Options;

        _context = new StockShortageDbContext(Options);

        ProductRepository = new ProductRepository(_context);
        NotifyRuleRepository = new NotifyRuleRepository(_context);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }


    public async Task InitializeAsync()
    {
        await SeedData();
    }

    public async Task DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    private async Task SeedData()
    {
        await ProductRepository.AddAsync(new Domain.Products.Entities.Product("books", Quantity.Create(25)),
            CancellationToken.None);
        await ProductRepository.AddAsync(new Domain.Products.Entities.Product("watches", Quantity.Create(5)),
            CancellationToken.None);


        await NotifyRuleRepository.AddAsync(new Domain.NotifyRules.Entities.NotifyRule("first", Quantity.Create(10)),
            CancellationToken.None);
        await NotifyRuleRepository.AddAsync(new Domain.NotifyRules.Entities.NotifyRule("second", Quantity.Create(20)),
            CancellationToken.None);

        SaveChanges();
    }
}