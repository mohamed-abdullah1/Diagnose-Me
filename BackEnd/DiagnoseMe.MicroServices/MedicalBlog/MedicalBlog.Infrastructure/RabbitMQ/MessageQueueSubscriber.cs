using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace MedicalBlog.Infrastructure.RabbitMQ;


public static class MessageQueueSubscriber
{
    public static void start(
        WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var serviceProvider = builder.Services.BuildServiceProvider();
        var rabbitMQSettings = new RabbitMQSettings();
        configuration.Bind("RabbitMQ", rabbitMQSettings);
        var rabbitMQConnector = RabbitMQConnector.ConnectAsync(rabbitMQSettings);
        MessageQueueHelper.SubscribeToRegisterUserQueue(rabbitMQConnector, serviceProvider);
        MessageQueueHelper.SubscribeToDeleteUserQueue(rabbitMQConnector, serviceProvider);
        MessageQueueHelper.SubscribeToUpdateUserQueue(rabbitMQConnector, serviceProvider);
        MessageQueueHelper.SubscribeToUpdateDoctorQueue(rabbitMQConnector, serviceProvider);
    }

}