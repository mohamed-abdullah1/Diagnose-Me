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
            var RabbitMQSettings = new RabbitMQSettings();
            configuration.Bind("RabbitMQ",RabbitMQSettings);
            services.AddSingleton(Options.Create(RabbitMQSettings));
            
            try{
                var rabbitMQConnector = RabbitMQConnector.ConnectAsync(RabbitMQSettings);
                services.AddSingleton(rabbitMQConnector);
                services.AddSingleton<IMessageQueueManager, MessageQueueManager>();
                MessageQueueHelper.SubscribeToRegisterUserQueue(rabbitMQConnector, services.BuildServiceProvider());
                MessageQueueHelper.SubscribeToDeleteUserQueue(rabbitMQConnector, services.BuildServiceProvider());
                MessageQueueHelper.SubscribeToUpdateUserQueue(rabbitMQConnector, services.BuildServiceProvider());
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return services;
        }
}