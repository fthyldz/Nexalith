namespace Nexalith.API.Middlewares.ExceptionHandlers;

public static class ServiceRegister
{
    public static IServiceCollection AddCommonExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }

    public static WebApplication UseCommonExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler();

        return app;
    }
}