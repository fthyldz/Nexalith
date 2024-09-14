using Nexalith.API.Endpoints.Common;

namespace Nexalith.API.Endpoints;

public abstract class BaseCreateEndpoint<TRequestDto, TRequest, TResponse, TResponseDto>(
    string pattern = "")
    : BaseEndpoint<TRequestDto, TRequest, TResponse, TResponseDto>(pattern)
    where TRequestDto : IBaseRequestDto<TResponseDto>
    where TRequest : IBaseCommandQuery<TResponse>
    where TResponse : IBaseResponse
    where TResponseDto : IBaseResponseDto
{
    public override IEndpointConventionBuilder AddRoutes(IEndpointRouteBuilder app)
    {
        return app.MapPost(Pattern,
            async (HttpContext context, IMediator mediator, [FromBody] TRequestDto requestDto) =>
            await HandleRequest(context, mediator, requestDto));
    }
}