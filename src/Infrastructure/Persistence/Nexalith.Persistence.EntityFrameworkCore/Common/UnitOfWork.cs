namespace Nexalith.Persistence.EntityFrameworkCore.Common;

public class UnitOfWork<TContext>(TContext context) : IUnitOfWork where TContext : DbContext
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
    {
        return new Repository<TContext, TEntity>(context);
    }
}