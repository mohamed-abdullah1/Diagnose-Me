using System.Text;
using Auth.Application.Authentication.Common;
using Auth.Application.Common.Interfaces.RabbitMQ;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
namespace Auth.Infrastructure.RabbitMQ;

public class MessageQueueManager : IMessageQueueManager
{
    private readonly IModel channel;
    public MessageQueueManager(IOptions<RabbitMQSettings> rabbitMqSettings)
    {
        
        channel = RabbitMQConnector.ConnectAsync(rabbitMqSettings.Value);
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthExchange, 
            type : ExchangeType.Fanout,
            durable: false,
            autoDelete: false);
    }

    public void DeleteUser(string userId)
    {
        channel.QueueDeclare(
            queue: RabbitMQConstants.DeletingUserQueue,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        channel.QueueBind(
            queue: RabbitMQConstants.DeletingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.DeletingUserQueue
        );
        
        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "text/plain";
        props.DeliveryMode = 2;

        byte[] body = Encoding.UTF8.GetBytes(userId);
        channel.BasicPublish(
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.DeletingUserQueue,
            mandatory: false,
            basicProperties: props,
            body: body);
    }

    public void PublishUser(ApplicationUserResponse user)
    {
        
        channel.QueueDeclare(
            queue: RabbitMQConstants.AddingUserQueue,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        channel.QueueBind(
            queue: RabbitMQConstants.AddingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.AddingUserQueue
        );
        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2;

        string serializedUser = JsonConvert.SerializeObject(user);
        byte[] body = Encoding.UTF8.GetBytes(serializedUser);

        channel.BasicPublish(
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.AddingUserQueue,
            mandatory: false,
            basicProperties: props,
            body: body);
    }

    public void UpdateUser(ApplicationUserResponse user)
    {
        channel.QueueDeclare(
            queue: RabbitMQConstants.UpdatingUserQueue,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        channel.QueueBind(
            queue: RabbitMQConstants.UpdatingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.UpdatingUserQueue
        );
        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2;

        string serializedUser = JsonConvert.SerializeObject(user);
        byte[] body = Encoding.UTF8.GetBytes(serializedUser);

        channel.BasicPublish(
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.UpdatingUserQueue,
            mandatory: false,
            basicProperties: props,
            body: body);
    }
}