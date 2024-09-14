using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nexalith.Application;
using Nexalith.Example.Application.Features.Categories.CategoryMappings;

namespace Nexalith.Example.Application;

public static class ServiceRegister
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddNexalithApplication(Assembly.GetExecutingAssembly());

        services.RegisterCategoryMappings();

        return services;
    }
}