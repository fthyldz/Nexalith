namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public static class ServiceRegister
{
    public static IServiceCollection AddNexalithExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<NexalithExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }

    public static WebApplication UseNexalithExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler();

        return app;
    }
}