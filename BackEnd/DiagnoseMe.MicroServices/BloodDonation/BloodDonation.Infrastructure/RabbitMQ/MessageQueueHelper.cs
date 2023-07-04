
using System.Text;
using MediatR;
using BloodDonation.Application.Authentication.Users.Commands.AddUser;
using BloodDonation.Application.Authentication.Users.Commands.DeleteUser;
using BloodDonation.Application.Authentication.Users.Commands.UpdateUser;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using ErrorOr;
using MapsterMapper;
using BloodDonation.Application.Authentication.Users.Common;
using System.Runtime.CompilerServices;

namespace BloodDonation.Infrastructure.RabbitMQ;

public class MessageQueueHelper
{
    
    public static Task SubscribeToRegisterUserQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthAddExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete: true
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.BloodDonationAddingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: true
        );

        channel.QueueBind(
            queue: RabbitMQConstants.BloodDonationAddingUserQueue,
            exchange: RabbitMQConstants.AuthAddExchange,
            routingKey: RabbitMQConstants.BloodDonationAddingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var userResponse = JsonConvert.DeserializeObject<ApplicationUserResponse>(UserDecoded);
            var mapper = (IMapper) serviceProvider.GetRequiredService(typeof(IMapper))!;
            var command = mapper.Map<AddUserCommand>(userResponse!);
            var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
            var result = await mediator.Send(command!);
            var logger = (ILogger) serviceProvider.GetRequiredService(typeof(ILogger))!;
            if (result.IsError)
            {
                Logging(logger, result.Errors);
            }
            else
            {
                logger.Information(result.Value.Message);
            }
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.BloodDonationAddingUserQueue,
            autoAck: false,
            consumer: consumer
        );
        return Task.CompletedTask;
    }

    public static Task SubscribeToDeleteUserQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthDeleteExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete: true
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.BloodDonationDeletingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: true
        );

        channel.QueueBind(
            queue: RabbitMQConstants.BloodDonationDeletingUserQueue,
            exchange: RabbitMQConstants.AuthDeleteExchange,
            routingKey: RabbitMQConstants.BloodDonationDeletingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var command = new DeleteUserCommand(UserDecoded);
            var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
            var result = await mediator.Send(command!);
            var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
            if (result.IsError)
            {
                Logging(logger, result.Errors);
            }
            else
            {
                logger.Information(result.Value.Message);
            }
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.BloodDonationDeletingUserQueue,
            autoAck: false,
            consumer: consumer
        );
        return Task.CompletedTask;
    }

    public static Task SubscribeToUpdateUserQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthUpdateExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete: true
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.BloodDonationUpdatingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: true
        );

        channel.QueueBind(
            queue: RabbitMQConstants.BloodDonationUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthUpdateExchange,
            routingKey: RabbitMQConstants.BloodDonationUpdatingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var userResponse = JsonConvert.DeserializeObject<ApplicationUserResponse>(UserDecoded);
            var mapper = (IMapper) serviceProvider.GetRequiredService(typeof(IMapper))!;
            var command = mapper.Map<UpdateUserCommand>(userResponse!);
            var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
            var result = await mediator.Send(command!);
            var logger = (Serilog.ILogger) serviceProvider.GetRequiredService(typeof(Serilog.ILogger))!;
            if (result.IsError)
            {
                Logging(logger, result.Errors);
            }
            else
            {
                logger.Information(result.Value.Message);
            }
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.BloodDonationUpdatingUserQueue,
            autoAck: false,
            consumer: consumer
        );
        return Task.CompletedTask;
    }

    private static void Logging (ILogger _logger, List<Error> errors,[CallerMemberName] string callingMethod = "")
    {
        
            _logger.Error(@$"An error has been occured..
                UserId: RabitMQ
                Called Method: {callingMethod}
                TraceId: 
                Errors: [{string.Join(", ", errors.Select(error => error.Description))}]");
    }
}
