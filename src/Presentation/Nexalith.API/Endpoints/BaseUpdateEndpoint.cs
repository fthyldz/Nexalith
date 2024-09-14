namespace Nexalith.Api.Endpoints;

public abstract class BaseUpdateEndpoint<TId, TRequestDto, TRequest, TResponse, TResponseDto>(
    string pattern = "{id}")
    : BaseEndpoint<TRequestDto, TRequest, TResponse, TResponseDto>(pattern)
    where TId : struct
    where TRequestDto : BaseUpdateRequestDto<TId, TResponseDto>
    where TRequest : IBaseCommandQuery<TResponse>
    where TResponse : IBaseResponse
    where TResponseDto : IBaseResponseDto
{
    public override IEndpointConventionBuilder AddRoutes(IEndpointRouteBuilder app)
    {
        return app.MapPut(Pattern,
            async (HttpContext context, IMediator mediator, TId id, [FromBody] TRequestDto requestDto) =>
            await HandleRequest(context, mediator, requestDto with { Id = id }));
    }
}