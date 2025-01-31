using Infrastructure.Events;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureConfiguration
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEventHandlers();
        services.AddDatabase(configuration);
        services.AddRepositories();
        services.AddNotificationService();
    }
}