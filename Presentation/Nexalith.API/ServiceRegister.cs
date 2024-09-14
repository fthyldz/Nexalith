namespace Nexalith.API;

public static class ServiceRegister
{
    public static IServiceCollection AddCommonApi(this IServiceCollection services, Assembly assembly)
    {
        services.AddCommonExceptionHandler();

        services.AddCommonCarter(assembly);

        return services;
    }

    public static WebApplication AddCommonApi(this WebApplication app)
    {
        app.UseCommonCarter();

        app.UseCommonExceptionHandler();

        return app;
    }
}