using Nexalith.Application.Cqrs.Request;

namespace Nexalith.Application.Cqrs.Handler;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse> where TResponse : notnull
{
}