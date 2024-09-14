using Nexalith.Application.Cqrs.Request;
using Nexalith.Application.Data;

namespace Nexalith.Application.Cqrs.Behaviors;

public class TransactionBehavior<TRequest, TResponse>(ITransactionManager transactionManager)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ITransactionalCommand<TResponse> where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        await transactionManager.BeginTransactionAsync(cancellationToken);

        TResponse response;

        try
        {
            response = await next();
            await transactionManager.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transactionManager.RollbackTransactionAsync(cancellationToken);
            throw;
        }

        return response;
    }
}