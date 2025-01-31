using Application.NotifyRule.CheckStockByProductId;
using Domain.Common.ValueObjects;
using Domain.Notifications;
using Domain.NotifyRules.Contracts;
using Domain.Products.Contracts;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Application.IntegrationTests;

public class CheckStockByProductIdEventHandlerTests : IClassFixture<TestDatabaseFixture>
{
    private readonly IServiceProvider _serviceProvider;
    private readonly TestDatabaseFixture _fixture;

    public CheckStockByProductIdEventHandlerTests(TestDatabaseFixture fixture)
    {
        _fixture = fixture;
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IProductRepository>(_ => _fixture.ProductRepository);
        serviceCollection.AddSingleton<INotifyRuleRepository>(_ => _fixture.NotifyRuleRepository);
        serviceCollection.AddSingleton<INotificationService, ConsoleNotifierService>();
        serviceCollection.AddScoped<CheckStockByProductIdEventHandler>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [Fact]
    public async Task HandleEvent_ShouldSendNotifications_WhenStockIsSufficient()
    {
        var publishedEvent = new CheckStockByProductIdEvent(1);
        
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var handler = _serviceProvider.GetRequiredService<CheckStockByProductIdEventHandler>();

        await handler.HandleEvent(publishedEvent, CancellationToken.None);

        var output = stringWriter.ToString();
        
        Assert.Contains("Rule(first) We have enough of books there is 25 in stock", output);
        Assert.Contains("Rule(second) We have enough of books there is 25 in stock", output);
    }

    [Fact]
    public async Task HandleEvent_ShouldSendLowStockNotification_WhenStockIsLow()
    {
        var publishedEvent = new CheckStockByProductIdEvent(2);

        Console.Clear();

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var handler = _serviceProvider.GetRequiredService<CheckStockByProductIdEventHandler>();

        await handler.HandleEvent(publishedEvent, CancellationToken.None);

        var output = stringWriter.ToString();
        
        Assert.Contains("Rule(first) We are running low on watches there is only 5 left", output);
        Assert.Contains("Rule(second) We are running low on watches there is only 5 left", output);
    }
    
}