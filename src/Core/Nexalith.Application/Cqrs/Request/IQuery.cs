namespace Nexalith.Application.Cqrs.Request;

public interface IQuery : IQuery<Unit>
{
}

public interface IQuery<out TResponse> : IBaseCommandQuery<TResponse> where TResponse : notnull
{
}