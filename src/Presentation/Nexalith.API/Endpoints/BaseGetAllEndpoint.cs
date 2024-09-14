using Nexalith.API.Endpoints.Common;

namespace Nexalith.API.Endpoints;

public abstract class BaseGetAllEndpoint<TRequestDto, TRequest, TResponse, TResponseDto>(
    string pattern = "")
    : BaseEndpoint<TRequestDto, TRequest, TResponse, TResponseDto>(pattern)
    where TRequestDto : IBaseRequestDto<TResponseDto>, new()
    where TRequest : IBaseCommandQuery<TResponse>, new()
    where TResponse : IBaseResponse
    where TResponseDto : IBaseResponseDto
{
    public override IEndpointConventionBuilder AddRoutes(IEndpointRouteBuilder app)
    {
        return app.MapGet(Pattern,
            async (HttpContext context, IMediator mediator) =>
                await HandleRequest(context, mediator, new TRequestDto()));
    }
}