using Application.Common.Events;
using Application.NotifyRule.CheckStock;
using Domain.Products.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Product;

public static class ProductConfiguration
{
    public static void AddProduct(this IServiceCollection services)
    {        
        services.AddTransient<IProductService, ProductService>();
    }
}