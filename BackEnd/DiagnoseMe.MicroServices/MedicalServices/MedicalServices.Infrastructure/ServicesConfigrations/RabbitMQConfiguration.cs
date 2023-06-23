using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Infrastructure.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MedicalServices.Infrastructure.ServicesConfigrations;

public static class RabbitMQConfiguration
{
    public static IServiceCollection AddRabbitMQConfiguration(
        this IServiceCollection services,
        IConfiguration configuration
        )
        {
            var RabbitMQSettings = new RabbitMQSettings();
            configuration.Bind("RabbitMQ",RabbitMQSettings);
            services.AddSingleton(Options.Create(RabbitMQSettings));
            
            services.AddSingleton<IMessageQueueManager, MessageQueueManager>();
            
            return services;
        }
}