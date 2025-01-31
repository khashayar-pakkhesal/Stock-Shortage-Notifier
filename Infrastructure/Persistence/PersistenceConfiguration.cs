using Application.Common.Events;
using Application.NotifyRule.CheckStock;
using Domain.NotifyRule.Contracts;
using Domain.Persistence;
using Domain.Product.Contracts;
using Infrastructure.Events;
using Infrastructure.Persistence.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class PersistenceConfiguration
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var defaultSqlConnectionStringBuilder =
            new SqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"))
            {
                TrustServerCertificate = true
            };

        services.AddDbContext<IUnitOfWork, StockShortageDbContext>(options =>
            options.UseSqlServer(defaultSqlConnectionStringBuilder.ConnectionString));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<INotifyRuleRepository, NotifyRuleRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}