using System.Text;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
namespace MedicalServices.Infrastructure.RabbitMQ;

public class MessageQueueManager : IMessageQueueManager
{
    private readonly IModel channel;
    public MessageQueueManager(IOptions<RabbitMQSettings> rabbitMqSettings)
    {
        
        channel = RabbitMQConnector.ConnectAsync(rabbitMqSettings.Value);
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.NotificationExchange, 
            type : ExchangeType.Fanout,
            durable: false,
            autoDelete: false);
    }

    public void PublishNotification(NotificationResponse notificationResponse)
    {
        channel.QueueDeclare(
            queue: RabbitMQConstants.NotificationQueue,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
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
            routingKey: RabbitMQConstants.NotificationQueue,
            mandatory: false,
            basicProperties: props,
            body: body);
    }

}