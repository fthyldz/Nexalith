namespace Nexalith.Persistence.EntityFrameworkCore;

public static class ServiceRegister
{
    public static IServiceCollection AddNexalithPersistence<TContext>(this IServiceCollection services,
        Action<DbContextOptionsBuilder> dbContextOptions)
        where TContext : DbContext
    {
        services.AddDbContext<TContext>(dbContextOptions);

        services.AddScoped<ITransactionManager, TransactionManager<TContext>>();

        services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();

        return services;
    }
}