namespace Nexalith.API.Middlewares.RequestValidationHandlers;

public static class ServiceRegister
{
    public static WebApplication UseCommonRequestValidationHandler(this WebApplication app)
    {
        app.UseMiddleware<RequestValidationHandler>();

        return app;
    }
}