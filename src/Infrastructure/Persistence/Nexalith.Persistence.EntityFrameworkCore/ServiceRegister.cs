using Nexalith.Persistence.EntityFrameworkCore.Common;

namespace Nexalith.Persistence.EntityFrameworkCore;

public static class ServiceRegister
{
    public static IServiceCollection AddCommonPersistence<TContext>(this IServiceCollection services,
        Action<DbContextOptionsBuilder> dbContextOptions)
        where TContext : DbContext
    {
        services.AddDbContext<TContext>(dbContextOptions);

        services.AddScoped(typeof(IRepository<>), typeof(Repository<,>));

        services.AddScoped<ITransactionManager, TransactionManager<TContext>>();

        services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();

        return services;
    }
}