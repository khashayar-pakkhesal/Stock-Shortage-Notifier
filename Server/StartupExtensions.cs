using System.Reflection;
using Domain.Common.ValueObjects;
using Domain.NotifyRules.Entities;
using Domain.Products.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Server.Contracts;

namespace Server;

public static class StartupExtensions
{
    public static void AddEndpoints(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);
    }

    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.ServiceProvider.GetRequiredService<IEnumerable<IEndpoint>>();

        foreach (var endpoint in endpoints)
            endpoint.MapEndpoint(app);
    }

    public static void MigrateAndSeedDatabase(this WebApplication webApplication)
    {
        using (var scope = webApplication.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<StockShortageDbContext>();
            dbContext.Database.Migrate();
            Seed(dbContext);
        }
    }

    private static void Seed(StockShortageDbContext dbContext)
    {
        if (!dbContext.NotifyRules.Any())
        {
            dbContext.NotifyRules.Add(new NotifyRule("First Rule", Quantity.Create(20)));
            dbContext.SaveChanges();
        }

        if (!dbContext.Products.Any())
        {
            dbContext.Products.Add(new Product("Books", Quantity.Create(15)));
            dbContext.Products.Add(new Product("Watches", Quantity.Create(25)));
            dbContext.SaveChanges();
        }
    }
}