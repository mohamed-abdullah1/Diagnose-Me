
using System.Text;
using MediatR;
using BloodDonation.Application.Authentication.Users.Commands.AddUser;
using BloodDonation.Application.Authentication.Users.Commands.DeleteUser;
using BloodDonation.Application.Authentication.Users.Commands.UpdateUser;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BloodDonation.Infrastructure.RabbitMQ;

public class MessageQueueHelper
{
    
    public static Task SubscribeToRegisterUserQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthExchange,
            type: ExchangeType.Fanout,
            durable: false,
            autoDelete: false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.AddingUserQueue,
            durable: false,
            exclusive: false,
            autoDelete: false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.AddingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.AddingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var user = JsonConvert.DeserializeObject<AddUserCommand>(UserDecoded);
            var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
            var result = await mediator.Send(user!);
            var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
            if (result.IsError)
            {
                var errors = JsonConvert.SerializeObject(result.Errors);
                logger.Error(JsonConvert.DeserializeObject<String>(errors)!);
            }
            else
            {
                logger.Information(result.Value.Message);
            }
        };
        return Task.CompletedTask;
    }

    public static Task SubscribeToDeleteUserQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthExchange,
            type: ExchangeType.Fanout,
            durable: false,
            autoDelete: false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.DeletingUserQueue,
            durable: false,
            exclusive: false,
            autoDelete: false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.DeletingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.DeletingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var user = JsonConvert.DeserializeObject<DeleteUserCommand>(UserDecoded);
            var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
            var result = await mediator.Send(user!);
            var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
            if (result.IsError)
            {
                var errors = JsonConvert.SerializeObject(result.Errors);
                logger.Error(JsonConvert.DeserializeObject<String>(errors)!);
            }
            else
            {
                logger.Information(result.Value.Message);
            }
        };
        return Task.CompletedTask;
    }

    public static Task SubscribeToUpdateUserQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthExchange,
            type: ExchangeType.Fanout,
            durable: false,
            autoDelete: false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.UpdatingUserQueue,
            durable: false,
            exclusive: false,
            autoDelete: false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.UpdatingUserQueue,
            exchange: RabbitMQConstants.AuthExchange,
            routingKey: RabbitMQConstants.UpdatingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var user = JsonConvert.DeserializeObject<UpdateUserCommand>(UserDecoded);
            var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
            var result = await mediator.Send(user!);
            var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
            if (result.IsError)
            {
                var errors = JsonConvert.SerializeObject(result.Errors);
                logger.Error(JsonConvert.DeserializeObject<String>(errors)!);
            }
            else
            {
                logger.Information(result.Value.Message);
            }
        };
        return Task.CompletedTask;
    }
}
