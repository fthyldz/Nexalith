namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public static class ServiceRegister
{
    public static IServiceCollection AddNexalithExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<BadRequestExceptionHandler>();
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<InternalServerExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }

    public static WebApplication UseNexalithExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler();

        return app;
    }
}