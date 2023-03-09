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
                    options.Authority = configuration.GetValue<string>("IdentityServer:Authority");
                    options.RequireHttpsMetadata = false;
                    options.Audience = "DiagnoseMe";
                });
            return services;
        }
}