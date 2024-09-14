namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger)
    : NexalithExceptionHandler<NotFoundExceptionHandler, NotFoundException>(logger, StatusCodes.Status404NotFound)
{
}