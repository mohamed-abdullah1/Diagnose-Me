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
            Port = rabbitMqSettings.Port
        };
        Console.WriteLine("=========================================");
        Console.WriteLine(rabbitMqSettings.Host);
        Console.WriteLine(rabbitMqSettings.Username);
        Console.WriteLine(rabbitMqSettings.Password);
        Console.WriteLine(rabbitMqSettings.Port);
        Console.WriteLine("=========================================");
        return factory.CreateConnection().CreateModel();
    }
}    