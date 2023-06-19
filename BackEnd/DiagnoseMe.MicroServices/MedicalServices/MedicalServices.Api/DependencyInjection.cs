using MedicalServices.Api.Common.Mapping;
using MedicalServices.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MedicalServices.Api.Configurations;

namespace MedicalServices.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddMapping();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory,MedicalServicesProblemDetailsFactory>();
        services.AddConfigurations(builder);
        return services;
    }
}