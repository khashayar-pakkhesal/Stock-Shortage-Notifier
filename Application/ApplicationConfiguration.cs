using Application.NotifyRule;
using Application.Product;
using Domain.Products.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationConfiguration
{
    public static void AddApplication(this IServiceCollection services)
    {        
        services.AddNotifyRule();
    } 
}