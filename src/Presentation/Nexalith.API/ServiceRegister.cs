namespace Nexalith.Api;

public static class ServiceRegister
{
    public static IServiceCollection AddNexalithApi(this IServiceCollection services, Assembly assembly)
    {
        services.AddNexalithExceptionHandler();

        services.AddNexalithCarter(assembly);

        return services;
    }

    public static WebApplication UseNexalithApi(this WebApplication app)
    {
        app.UseNexalithCarter();

        app.UseNexalithExceptionHandler();

        return app;
    }
}