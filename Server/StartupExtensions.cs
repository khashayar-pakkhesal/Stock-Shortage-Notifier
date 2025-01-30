using System.Reflection;
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
}