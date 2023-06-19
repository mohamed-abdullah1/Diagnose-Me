using MedicalServices.Api;
using MedicalServices.Infrastructue;
using MedicalServices.Persistence;
using MedicalServices.Application;
using MedicalServices.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRateLimit;
using Serilog;
using Microsoft.EntityFrameworkCore.Metadata;

var builder = WebApplication.CreateBuilder(args);


{
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
    builder.Services
        .AddPresentation(builder)
        .AddApplication(builder.Configuration)
        .AddPersistence(builder.Configuration)
        .AddInfrastrucure(builder.Configuration);
}

// try{
//     IModel channel = RabbitMQ
// }
var app = builder.Build();

{
    using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
    {
        var context = serviceScope?.ServiceProvider.GetRequiredService<ApplicationDbContext>()!;

        context.Database.Migrate();

    }
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