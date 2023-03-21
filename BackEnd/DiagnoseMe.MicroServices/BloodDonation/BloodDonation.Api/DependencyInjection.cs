using BloodDonation.Api.Common.Mapping;
using BloodDonation.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BloodDonation.Api.Configurations;

namespace BloodDonation.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddMapping();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory,BloodDonationProblemDetailsFactory>();
        services.AddCorsConfigurations(configuration);
        return services;
    }
}