namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public class ValidationExceptionHandler(ILogger<ValidationExceptionHandler> logger)
    : BaseExceptionHandler<ValidationExceptionHandler, ValidationException>(logger, StatusCodes.Status400BadRequest)
{
}