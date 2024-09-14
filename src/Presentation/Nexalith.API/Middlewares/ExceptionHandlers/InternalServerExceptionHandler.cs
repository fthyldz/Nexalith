namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public class InternalServerExceptionHandler(ILogger<InternalServerExceptionHandler> logger)
    : NexalithExceptionHandler<InternalServerExceptionHandler, Exception>(logger,
        StatusCodes.Status500InternalServerError)
{
}