using Auth.Api.Common.Errors;
using Auth.Api.Common.Mapping;
using Auth.Api.Configurations;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Auth.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddMapping();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory,AuthProblemDetailsFactory>();
        services.AddConfigurations(configuration);
        return services;
    }
}