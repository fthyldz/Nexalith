namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger)
    : BaseExceptionHandler<NotFoundExceptionHandler, NotFoundException>(logger, StatusCodes.Status404NotFound)
{
}