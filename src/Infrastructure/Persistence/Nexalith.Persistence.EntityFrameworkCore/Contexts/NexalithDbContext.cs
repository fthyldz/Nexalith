namespace Nexalith.Persistence.EntityFrameworkCore.Contexts;

public abstract class NexalithDbContext : DbContext
{
}

public abstract class NexalithDbContext<TContext> : DbContext
    where TContext : DbContext
{
    public NexalithDbContext(DbContextOptions<TContext> options) : base(options)
    {
    }
}