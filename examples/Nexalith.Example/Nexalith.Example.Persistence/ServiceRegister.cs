using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nexalith.Example.Persistence.Contexts;
using Nexalith.Persistence.EntityFrameworkCore;

namespace Nexalith.Example.Persistence;

public static class ServiceRegister
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddNexalithPersistence<ApplicationDbContext>(dbContextOptions =>
            dbContextOptions.UseNpgsql(connectionString));

        return services;
    }
}