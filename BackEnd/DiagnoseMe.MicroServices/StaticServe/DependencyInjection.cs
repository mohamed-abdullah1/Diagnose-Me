
using StaticServe.Configurations;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using StaticServe.Common.Errors;
using StaticServe.ServicesConfigrations;

namespace StaticServe;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory,StaticServeProblemDetailsFactory>();
        services.AddConfigurations(builder);
        services.AddRabbitMQConfiguration(builder.Configuration);
        return services;
    }
}