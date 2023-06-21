using System.Text;
using Auth.Application.Authentication.Common;
using Auth.Application.Common.Interfaces.RabbitMQ;
using Auth.Application.MedicalBlog.Common;
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
        
    }

    public void DeleteUser(string userId)
    {
        Publish(
            exchange: RabbitMQConstants.AuthDeleteExchange,
            queues: RabbitMQConstants.DeleteQueues,
            obj: userId,
            contentType: "text/plain"
        );
    }

    public void PublishNotification(NotificationResponse notificationResponse)
    {
        Publish(
            exchange: RabbitMQConstants.NotificationExchange,
            queues: new List<string>() { RabbitMQConstants.NotificationQueue },
            obj: notificationResponse,
            contentType: "application/json"
        );
    }

    public void PublishUser(ApplicationUserResponse user)
    {
        Publish(
            exchange: RabbitMQConstants.AuthAddExchange,
            queues: RabbitMQConstants.AddQueues,
            obj: user,
            contentType: "application/json"
        );
    }

    public void UpdateUser(ApplicationUserResponse user)
    {
        Publish(
            exchange: RabbitMQConstants.AuthUpdateExchange,
            queues: RabbitMQConstants.UpdateQueues,
            obj: user,
            contentType: "application/json"
        );
    }

    private void Publish(
        string exchange,
        List<string> queues,
        Object obj,
        string contentType)
    {
        channel.ExchangeDeclare(
            exchange: exchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete: false
        );

        foreach (var queue in queues)
        {
            channel.QueueDeclare(
                queue: queue,
                durable: true,
                exclusive: false,
                autoDelete: false);
        }

        foreach (var queue in queues)
        {
            channel.QueueBind(
                queue: queue,
                exchange: exchange,
                routingKey: queue
            );
        }

        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = contentType;
        props.DeliveryMode = 2;

        byte[] body = new byte[] { };
        if (contentType == "text/plain")
        {
            body = Encoding.UTF8.GetBytes(obj.ToString()!);
        }
        else{
            string serializedObject = JsonConvert.SerializeObject(obj);
            body = Encoding.UTF8.GetBytes(serializedObject);}

        channel.BasicPublish(
            exchange: exchange,
            routingKey: String.Empty,
            mandatory: false,
            basicProperties: props,
            body: body);
    }
}