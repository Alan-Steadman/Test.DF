using Test.DF.Infrastructure.State;

namespace Test.DF.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddClientInfrastructure(this IServiceCollection services)
    {
        services.AddStateContainer();
        return services;
    }

    private static IServiceCollection AddStateContainer(this IServiceCollection services)
    {
        services.AddScoped<AppStateContainer>();

        return services;
    }


}
