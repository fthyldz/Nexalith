namespace Nexalith.Application.Data;

public interface IUnitOfWork
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}