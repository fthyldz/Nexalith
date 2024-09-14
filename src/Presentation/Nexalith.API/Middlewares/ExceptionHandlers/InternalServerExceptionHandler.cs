namespace Nexalith.Api.Middlewares.ExceptionHandlers;

public class InternalServerExceptionHandler(ILogger<InternalServerExceptionHandler> logger)
    : BaseExceptionHandler<InternalServerExceptionHandler, InternalServerException>(logger,
        StatusCodes.Status500InternalServerError)
{
}