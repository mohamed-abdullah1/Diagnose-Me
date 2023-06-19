using System.Text;
using MedicalBlog.Application.Common.Interfaces.RabbitMQ;
using MedicalBlog.Application.MedicalBlog.Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
namespace MedicalBlog.Infrastructure.RabbitMQ;

public class MessageQueueManager : IMessageQueueManager
{
    private readonly IModel channel;
    public MessageQueueManager(IOptions<RabbitMQSettings> rabbitMqSettings)
    {
        
        channel = RabbitMQConnector.ConnectAsync(rabbitMqSettings.Value);

    }

    public void PublishNotification(NotificationResponse notificationResponse)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.NotificationExchange, 
            type : ExchangeType.Fanout,
            durable: true,
            autoDelete: false);

        channel.QueueDeclare(
            queue: RabbitMQConstants.NotificationQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);
        channel.QueueBind(
            queue: RabbitMQConstants.NotificationQueue,
            exchange: RabbitMQConstants.NotificationExchange,
            routingKey: RabbitMQConstants.NotificationQueue
        );
        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2;

        string serializedNotification = JsonConvert.SerializeObject(notificationResponse);
        byte[] body = Encoding.UTF8.GetBytes(serializedNotification);

        channel.BasicPublish(
            exchange: RabbitMQConstants.NotificationExchange,
            routingKey: String.Empty,
            mandatory: false,
            basicProperties: props,
            body: body);
    }

}