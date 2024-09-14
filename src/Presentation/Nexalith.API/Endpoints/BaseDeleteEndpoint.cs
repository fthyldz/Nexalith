namespace Nexalith.Api.Endpoints;

public abstract class BaseDeleteEndpoint<TId, TRequestDto, TRequest, TResponse, TResponseDto>(
    string pattern = "{id}")
    : BaseEndpoint<TRequestDto, TRequest, TResponse, TResponseDto>(pattern)
    where TId : struct
    where TRequestDto : BaseDeleteRequestDto<TId, TResponseDto>
    where TRequest : IBaseCommandQuery<TResponse>
    where TResponse : IBaseResponse
    where TResponseDto : IBaseResponseDto
{
    public override IEndpointConventionBuilder AddRoutes(IEndpointRouteBuilder app)
    {
        return app.MapDelete(Pattern,
            async (HttpContext context, IMediator mediator, TId id) => await HandleRequest(context, mediator,
                new BaseDeleteRequestDto<TId, TResponseDto>(id).Adapt<TRequestDto>()));
    }
}