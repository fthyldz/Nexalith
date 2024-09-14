namespace Nexalith.Application.Data;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>>? expression = null);
    TEntity Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}