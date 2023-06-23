using MedicalBlog.Api;
using MedicalBlog.Infrastructue;
using MedicalBlog.Persistence;
using MedicalBlog.Application;
using MedicalBlog.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRateLimit;
using MedicalBlog.Infrastructure.RabbitMQ;

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
    MessageQueueSubscriber.start(builder.Services.BuildServiceProvider(), builder.Configuration);
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