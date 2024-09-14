namespace Nexalith.Application;

public static class ServiceRegister
{
    public static IServiceCollection AddNexalithApplication(this IServiceCollection services, Assembly assembly)
    {
        services.AddNexalithCqrs(assembly);

        services.AddNexalithFluentValidation(assembly);

        return services;
    }
}