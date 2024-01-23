using Test.DF.Infrastructure.Services;
using Test.DF.Infrastructure.State;

namespace Test.DF.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddClientInfrastructure(this IServiceCollection services)
    {
        services.AddStateContainer();
        services.AddDateTimeProvider();

        return services;
    }

    private static IServiceCollection AddStateContainer(this IServiceCollection services)
    {
        services.AddScoped<AppStateContainer>();

        return services;
    }

    private static IServiceCollection AddDateTimeProvider(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
