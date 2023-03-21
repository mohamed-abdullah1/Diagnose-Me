using Auth.Application.Common.Interfaces.RabbitMq;
using Auth.Infrastructure.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Auth.Infrastructure.ServicesConfigrations;

public static class RabbitMqConfiguration
{
    public static IServiceCollection AddRabbitMqConfiguration(
        this IServiceCollection services,
        IConfiguration configuration
        )
        {
            var RabbitMqSettings = new RabbitMqSettings();
            configuration.Bind("RabbitMqSettings",RabbitMqSettings);
            services.AddSingleton(Options.Create(RabbitMqSettings));
            
            services.AddSingleton<IMessageQueueManager, MessageQueueManager>();
            return services;
        }
}