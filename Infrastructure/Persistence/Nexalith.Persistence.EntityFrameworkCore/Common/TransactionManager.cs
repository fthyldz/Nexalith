namespace Nexalith.Persistence.EntityFrameworkCore.Common;

public class TransactionManager<TContext>(TContext context)
    : ITransactionManager, IDisposable, IAsyncDisposable where TContext : DbContext
{
    private IDbContextTransaction? _transaction;

    public async ValueTask DisposeAsync()
    {
        if (_transaction is not null) await _transaction.DisposeAsync();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null) throw new InvalidOperationException("A transaction is already in progress.");

        _transaction = await context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction == null) throw new InvalidOperationException("No transaction is in progress.");

        try
        {
            await context.SaveChangesAsync(cancellationToken);
            await _transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync(cancellationToken);
            _transaction.Dispose();
            _transaction = null;
        }
    }
}