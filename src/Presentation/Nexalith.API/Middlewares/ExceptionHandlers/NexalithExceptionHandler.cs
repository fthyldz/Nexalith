namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public abstract class NexalithExceptionHandler<TExceptionHandler, TExceptionType>(
    ILogger<TExceptionHandler> logger,
    int statusCode)
    : IExceptionHandler
    where TExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError("Error Message: {exceptionMessage}, Time of occurrence {time}", exception.Message,
            DateTime.UtcNow);

        if (exception is not TExceptionType)
            return false;

        var problemDetails = new ProblemDetails
        {
            Title = exception.GetType().Name,
            Status = statusCode,
            Detail = exception.Message,
            Instance = httpContext.Request.Path
        };

        problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);

        if (exception is ValidationException validationException)
            problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}