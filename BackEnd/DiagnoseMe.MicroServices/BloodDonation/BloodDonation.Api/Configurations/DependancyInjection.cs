namespace BloodDonation.Api.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddConfigurations(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCorsConfigurations(configuration);
        return services;
    }
}