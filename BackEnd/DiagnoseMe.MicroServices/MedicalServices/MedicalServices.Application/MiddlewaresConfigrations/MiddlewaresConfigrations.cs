using MedicalServices.Application.MiddlewaresConfigurations.Middlewares;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalServices.Application.MiddlewaresConfigurations;

public static class MiddlewaresConfigurations
{
    public static IServiceCollection AddMiddlewares(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddRateLimit(configuration);
        return services;
    }
}