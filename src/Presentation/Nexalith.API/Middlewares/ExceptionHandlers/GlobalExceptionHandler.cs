namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    : BaseExceptionHandler<GlobalExceptionHandler, Exception>(logger,
        StatusCodes.Status500InternalServerError)
{
}