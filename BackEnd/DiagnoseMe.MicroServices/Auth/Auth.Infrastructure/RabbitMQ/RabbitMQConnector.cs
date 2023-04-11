using RabbitMQ.Client;

namespace Auth.Infrastructure.RabbitMQ;


public static class RabbitMQConnector
{
    public static IModel ConnectAsync(RabbitMQSettings rabbitMqSettings)
    {
        var factory = new ConnectionFactory()
        {
            HostName = rabbitMqSettings.Host,
            UserName = rabbitMqSettings.Username,
            Password = rabbitMqSettings.Password,
            VirtualHost = rabbitMqSettings.VirtualHost,
            Port = rabbitMqSettings.Port
        };
        return factory.CreateConnection().CreateModel();
    }
}    