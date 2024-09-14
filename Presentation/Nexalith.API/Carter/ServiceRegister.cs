namespace Nexalith.API.Carter;

public static class ServiceRegister
{
    public static IServiceCollection AddCommonCarter(this IServiceCollection services, Assembly assembly)
    {
        services.AddCarter(new DependencyContextAssemblyCatalog([assembly]));

        return services;
    }

    public static WebApplication UseCommonCarter(this WebApplication app)
    {
        app.MapCarter();

        return app;
    }
}