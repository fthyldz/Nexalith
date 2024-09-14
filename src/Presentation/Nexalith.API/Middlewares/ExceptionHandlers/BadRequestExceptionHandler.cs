namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public class BadRequestExceptionHandler(ILogger<BadRequestExceptionHandler> logger)
    : NexalithExceptionHandler<BadRequestExceptionHandler, BadRequestException>(logger, StatusCodes.Status400BadRequest)
{
}