using DiagnoseMe.GateWay.MiddlewaresConfigrations;
using Ocelot.DependencyInjection;
using DiagnoseMe.GateWay.ServicesConfigurations;

namespace DiagnoseMe.GateWay;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddOcelot(configuration);
        services.AddMiddlewares(configuration);
        services.AddCorsConfiguration();
        return services;
    }
}