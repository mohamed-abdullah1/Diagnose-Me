
namespace DiagnoseMe.GateWay.MiddlewaresConfigrations;

public static class MiddlewaresConfigrations
{
    public static IServiceCollection AddMiddlewares(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        return services;
    }
}