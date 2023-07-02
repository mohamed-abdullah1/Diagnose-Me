namespace Auth.Api.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddConfigurations(
        this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddCorsConfigurations(builder.Configuration);
        services.AddSerilogConfiguration(builder);
        return services;
    }
}