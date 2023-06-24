

namespace StaticServe.RabbitMQ;


public static class MessageQueueSubscriber
{
    public static void start(
        IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        var rabbitMQSettings = new RabbitMQSettings();
        configuration.Bind("RabbitMQ", rabbitMQSettings);
        var rabbitMQConnector = RabbitMQConnector.ConnectAsync(rabbitMQSettings);
        MessageQueueHelper.SubscribeToSaveQueue(rabbitMQConnector, serviceProvider);
        MessageQueueHelper.SubscribeToDeleteQueue(rabbitMQConnector, serviceProvider);
    }

}