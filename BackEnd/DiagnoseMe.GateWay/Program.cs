using System.Net;
using DiagnoseMe.GateWay;
using Ocelot.Middleware;
using Serilog;


ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
        .AddJsonFile("OcelotConfiguration/Global.json", optional: false, reloadOnChange: true)
        .AddJsonFile("OcelotConfiguration/Auth.json", optional: false, reloadOnChange: true)
        .AddJsonFile("OcelotConfiguration/MedicalBlog.json", optional: false, reloadOnChange: true)
        .AddJsonFile("OcelotConfiguration/BloodDonation.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();
{
    builder.Services.AddPresentation(builder.Configuration);
    Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File("logs/gateway-.txt", rollingInterval: RollingInterval.Day)
                    .MinimumLevel.Debug()
                    .CreateLogger();
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(Log.Logger);
    Serilog.ILogger logger = Log.Logger.ForContext<Program>();
    builder.Services.AddSingleton<Serilog.ILogger>(logger);
    logger.Information("Starting up");
}
var app = builder.Build();
{
    await app.UseOcelot();
    app.UseAuthentication();
    app.UseAuthorization();
}

app.Run();
