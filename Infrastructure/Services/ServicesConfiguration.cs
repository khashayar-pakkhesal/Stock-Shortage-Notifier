using Domain.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public static class ServicesConfiguration
{
    public static void AddNotificationService(this IServiceCollection services)
    {
        services.AddScoped<INotificationService, ConsoleNotifierService>();
    }
}