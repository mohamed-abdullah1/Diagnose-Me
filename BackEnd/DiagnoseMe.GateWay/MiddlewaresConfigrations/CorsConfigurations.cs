namespace DiagnoseMe.GateWay.MiddlewaresConfigrations;

public static class CorsConfigurations
{
    public static IServiceCollection AddCorsConfigurations(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
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