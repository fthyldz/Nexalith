namespace Nexalith.Api.Carter;

public static class ServiceRegister
{
    public static IServiceCollection AddNexalithCarter(this IServiceCollection services, Assembly assembly)
    {
        services.AddCarter(new DependencyContextAssemblyCatalog([assembly]));

        return services;
    }

    public static WebApplication UseNexalithCarter(this WebApplication app)
    {
        app.MapCarter();

        return app;
    }
}