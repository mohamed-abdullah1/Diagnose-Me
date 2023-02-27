using MedicalServices.Application.MiddlewaresConfigrations.Middlewares;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalServices.Application.MiddlewaresConfigrations;

public static class MiddlewaresConfigrations
{
    public static IServiceCollection AddMiddlewares(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddRateLimit(configuration);
        return services;
    }
}