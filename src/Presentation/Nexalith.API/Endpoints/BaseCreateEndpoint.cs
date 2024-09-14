namespace Nexalith.Api.Endpoints;

public abstract class BaseCreateEndpoint<TRequestDto, TRequest, TResponse, TResponseDto, TId>(
    string pattern = "")
    : BaseEndpoint<TRequestDto, TRequest, TResponse, TResponseDto>(pattern)
    where TRequestDto : IBaseRequestDto<TResponseDto>
    where TRequest : IBaseCommandQuery<TResponse>
    where TResponse : IBaseResponse
    where TResponseDto : BaseCreateResponseDto<TId>
    where TId : struct
{
    public override IEndpointConventionBuilder AddRoutes(IEndpointRouteBuilder app)
    {
        return app.MapPost(Pattern,
            async (HttpContext context, IMediator mediator, [FromBody] TRequestDto requestDto) =>
            await HandleRequest(context, mediator, requestDto));
    }
}