using BloodDonation.Api;
using BloodDonation.Infrastructue;
using BloodDonation.Persistence;
using BloodDonation.Application;
using BloodDonation.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRateLimit;
using Serilog;
using BloodDonation.Infrastructure.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);


{
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
    builder.Services
        .AddPresentation(builder)
        .AddApplication(builder.Configuration)
        .AddPersistence(builder.Configuration)
        .AddInfrastrucure(builder.Configuration);
    
}

var app = builder.Build();

{
    using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
    {
        var context = serviceScope?.ServiceProvider.GetRequiredService<ApplicationDbContext>()!;

        context.Database.Migrate();

    }
    MessageQueueSubscriber.start(builder);
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseIpRateLimiting();
    app.UseExceptionHandler("/error");
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseCors("CorsPolicy");
    app.Run();
}