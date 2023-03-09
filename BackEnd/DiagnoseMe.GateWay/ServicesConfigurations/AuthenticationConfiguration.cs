namespace DiagnoseMe.GateWay.ServicesConfigurations;

public static class AuthenticationConfiguration
{
    public static IServiceCollection AddAuthenticationService(
        this IServiceCollection services,
        ConfigurationManager configuration
        )
        {
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://auth.diagnose.me:9075";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "DiagnoseMeApiUsers";
                });
            return services;
        }
}