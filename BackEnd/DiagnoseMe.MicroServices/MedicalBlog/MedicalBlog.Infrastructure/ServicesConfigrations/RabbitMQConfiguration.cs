using MedicalBlog.Application.Common.Interfaces.RabbitMQ;
using MedicalBlog.Infrastructure.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MedicalBlog.Infrastructure.ServicesConfigrations;

public static class RabbitMQConfiguration
{
    public static IServiceCollection AddRabbitMQConfiguration(
        this IServiceCollection services,
        IConfiguration configuration
        )
        {
            services.AddSingleton<IMessageQueueManager, MessageQueueManager>();
            
            return services;
        }
}