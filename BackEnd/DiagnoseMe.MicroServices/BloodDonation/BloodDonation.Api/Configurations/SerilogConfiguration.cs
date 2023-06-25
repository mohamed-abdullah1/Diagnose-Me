using Serilog;

namespace BloodDonation.Api.Configurations;


public static class SerilogConfiguration
{
    public static IServiceCollection AddSerilogConfiguration(
        this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File("logs/blood_donation-.txt", rollingInterval: RollingInterval.Day)
                    .MinimumLevel.Debug()
                    .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(Log.Logger);
        Serilog.ILogger logger = Log.Logger.ForContext<Program>();
        builder.Services.AddSingleton<Serilog.ILogger>(logger);
        logger.Information("Starting up");
        return services;
    }
}