namespace Nexalith.Application.FluentValidation;

public static class ServiceRegister
{
    public static IServiceCollection AddCommonFluentValidation(this IServiceCollection services, Assembly assembly)
    {
        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}