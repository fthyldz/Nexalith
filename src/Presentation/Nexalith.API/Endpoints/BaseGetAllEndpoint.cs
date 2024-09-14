namespace Nexalith.Api.Endpoints;

public abstract class BaseGetAllEndpoint<TRequestDto, TRequest, TResponse, TResponseDto, TDto>(
    string pattern = "")
    : BaseEndpoint<TRequestDto, TRequest, TResponse, TResponseDto>(pattern)
    where TRequestDto : IBaseRequestDto<TResponseDto>, new()
    where TRequest : IBaseCommandQuery<TResponse>, new()
    where TResponse : IBaseResponse
    where TResponseDto : BaseGetAllResponseDto<TDto>
    where TDto : class
{
    public override IEndpointConventionBuilder AddRoutes(IEndpointRouteBuilder app)
    {
        return app.MapGet(Pattern,
            async (HttpContext context, IMediator mediator) =>
                await HandleRequest(context, mediator, new TRequestDto()));
    }
}