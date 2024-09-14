namespace Nexalith.Application.Cqrs.Request;

public interface IBaseCommandQuery : IBaseCommandQuery<Unit>
{
}

public interface IBaseCommandQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}