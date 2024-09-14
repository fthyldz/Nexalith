using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nexalith.Example.Persistence.Contexts;

namespace Nexalith.Example.Persistence.Extensions;

public static class DbExtensions
{
    public static async Task MigrateDatabaseAsync(this IHost app)
    {
        await using var scope = app.Services.CreateAsyncScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync();
    }
}