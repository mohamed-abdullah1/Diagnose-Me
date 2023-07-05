using StaticServe.RabbitMQ;
using Microsoft.Extensions.Options;

namespace StaticServe.ServicesConfigrations;

public static class RabbitMQConfiguration
{
    public static IServiceCollection AddRabbitMQConfiguration(
        this IServiceCollection services,
        IConfiguration configuration
        )
        {
            var rabbitMQSettings = new RabbitMQSettings();
            configuration.Bind("RabbitMQ", rabbitMQSettings);
            services.AddSingleton(Options.Create(rabbitMQSettings));
            
            return services;
        }
}