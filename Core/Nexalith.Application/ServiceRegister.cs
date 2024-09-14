namespace Nexalith.Application;

public static class ServiceRegister
{
    public static IServiceCollection AddCommonApplication(this IServiceCollection services, Assembly assembly)
    {
        services.AddCommonCqrs(assembly);
        services.AddCommonFluentValidation(assembly);

        return services;
    }
}