namespace Nexalith.Api.Endpoints.Common;

public abstract class BaseEndpoint<TRequestDto, TRequest, TResponse, TResponseDto>(
    string pattern = "")
    where TRequestDto : IBaseRequestDto<TResponseDto>
    where TRequest : IBaseCommandQuery<TResponse>
    where TResponse : IBaseResponse
    where TResponseDto : IBaseResponseDto
{
    protected readonly string Pattern = pattern;

    public abstract IEndpointConventionBuilder AddRoutes(IEndpointRouteBuilder app);

    protected virtual async Task<IResult> HandleRequest(HttpContext context, IMediator mediator, TRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        await ValidateRequest(context, requestDto, cancellationToken);

        var request = await ConvertToRequest(requestDto, cancellationToken);

        var response = await SendToHandler(mediator, request, cancellationToken);

        var responseDto = await ConvertToResponse(response, cancellationToken);

        return await ReturnResponse(responseDto, cancellationToken);
    }

    protected virtual async Task ValidateRequest(HttpContext context, TRequestDto request,
        CancellationToken cancellationToken = default)
    {
        var validators =
            (IEnumerable<IValidator<TRequestDto>>)context.RequestServices.GetRequiredService(
                typeof(IEnumerable<IValidator<TRequestDto>>));

        var validationContext = new ValidationContext<TRequestDto>(request);

        var validationResult =
            await Task.WhenAll(validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));

        var failures = validationResult.Where(r => r.Errors.Count != 0).SelectMany(r => r.Errors).ToList();

        if (failures.Count != 0)
            throw new ValidationException(failures);
    }

    protected virtual async Task<TRequest> ConvertToRequest(TRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(requestDto.Adapt<TRequest>());
    }

    protected virtual async Task<TResponse> SendToHandler(IMediator mediator, TRequest request,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(request, cancellationToken);
    }

    protected virtual async Task<TResponseDto> ConvertToResponse(TResponse result,
        CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(result.Adapt<TResponseDto>());
    }

    protected virtual async Task<IResult> ReturnResponse(TResponseDto responseDto,
        CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(Results.Ok(responseDto));
    }
}