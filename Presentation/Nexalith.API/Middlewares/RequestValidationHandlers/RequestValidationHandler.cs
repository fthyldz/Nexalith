using Carter.ModelBinding;

namespace Nexalith.API.Middlewares.RequestValidationHandlers;

public class RequestValidationHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var request = await context.Request.ReadFromJsonAsync<object>();
        var validationResult = context.Request.Validate(request);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
        await next(context);
    }
}