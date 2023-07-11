namespace MedicalBlog.Api.Configurations;

public static class CorsConfigurations
{
    public static IServiceCollection AddCorsConfigurations(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCors(options =>
        {
            var allowedorigins = new List<string>();
            configuration.Bind("AllowedOrigins", allowedorigins);
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }
}