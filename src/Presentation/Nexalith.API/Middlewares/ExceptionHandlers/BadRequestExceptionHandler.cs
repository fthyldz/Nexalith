namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public class BadRequestExceptionHandler(ILogger<BadRequestExceptionHandler> logger)
    : BaseExceptionHandler<BadRequestExceptionHandler, BadRequestException>(logger, StatusCodes.Status400BadRequest)
{
}