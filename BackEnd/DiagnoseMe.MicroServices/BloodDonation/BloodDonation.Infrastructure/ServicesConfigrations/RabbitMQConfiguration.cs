using BloodDonation.Application.Common.Interfaces.RabbitMQ;
using BloodDonation.Infrastructure.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BloodDonation.Infrastructure.ServicesConfigrations;

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
            services.AddSingleton<IMessageQueueManager, MessageQueueManager>();
            
            return services;
        }
}