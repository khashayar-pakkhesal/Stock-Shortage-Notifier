using Infrastructure.Events;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddEventHandlers();
    }
}