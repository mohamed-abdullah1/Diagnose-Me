using MedicalBlog.Api.Common.Mapping;
using MedicalBlog.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MedicalBlog.Api.Configurations;

namespace MedicalBlog.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddMapping();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory,MedicalBlogProblemDetailsFactory>();
        services.AddCorsConfigurations(builder.Configuration);
        services.AddConfigurations(builder);
        return services;
    }
}