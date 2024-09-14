namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public class ValidationExceptionHandler(ILogger<ValidationExceptionHandler> logger)
    : NexalithExceptionHandler<ValidationExceptionHandler, ValidationException>(logger, StatusCodes.Status400BadRequest)
{
}