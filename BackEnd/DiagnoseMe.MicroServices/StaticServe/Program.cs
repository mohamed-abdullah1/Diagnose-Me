using Microsoft.Extensions.FileProviders;
using StaticServe;
using StaticServe.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPresentation(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "Files")),
        RequestPath = "/files"
    });
}
// MessageQueueSubscriber.start(builder);
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.Run();
