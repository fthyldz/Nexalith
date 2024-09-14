namespace Nexalith.Persistence.EntityFrameworkCore.Common;

public class Repository<TContext, TEntity>(TContext context) : IRepository<TEntity>
    where TContext : DbContext where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>>? expression = null)
    {
        return expression is null
            ? _dbSet
            : _dbSet.Where(expression);
    }

    public TEntity Add(TEntity entity)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}