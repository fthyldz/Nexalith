using Nexalith.Application.Cqrs.Behaviors;

namespace Nexalith.Application.Cqrs;

public static class ServiceRegister
{
    public static IServiceCollection AddCommonCqrs(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });

        return services;
    }
}