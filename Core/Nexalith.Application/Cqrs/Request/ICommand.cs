namespace Nexalith.Application.Cqrs.Request;

public interface ITransactionalCommand : ITransactionalCommand<Unit>
{
}

public interface ITransactionalCommand<out TResponse> : ICommand<TResponse> where TResponse : notnull
{
}

public interface ICommand : ICommand<Unit>
{
}

public interface ICommand<out TResponse> : IBaseCommandQuery<TResponse> where TResponse : notnull
{
}