using Microsoft.EntityFrameworkCore;
using Nexalith.Example.Domain.Entities;
using Nexalith.Persistence.EntityFrameworkCore.Contexts;

namespace Nexalith.Example.Persistence.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : NexalithDbContext<ApplicationDbContext>(options)
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}