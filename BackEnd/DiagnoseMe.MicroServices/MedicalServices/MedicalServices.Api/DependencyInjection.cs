using MedicalServices.Api.Common.Mapping;
using MedicalServices.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MedicalServices.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services)
    {
        services.AddMapping();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory,MedicalServicesProblemDetailsFactory>();
        return services;
    }
}