
using System.Text;
using ErrorOr;
using MapsterMapper;
using MediatR;
using MedicalServices.Application.Authentication.Users.Commands.AddUser;
using MedicalServices.Application.Authentication.Users.Commands.DeleteUser;
using MedicalServices.Application.Authentication.Users.Commands.UpdateUser;
using MedicalServices.Application.Authentication.Users.Common;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;

namespace MedicalServices.Infrastructure.RabbitMQ;

public class MessageQueueHelper
{
    
    public static Task SubscribeToRegisterUserQueue(IModel channel, IServiceProvider serviceProvider)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthAddExchange,
            type: ExchangeType.Fanout,
            durable: true,
            autoDelete: false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalServicesAddingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalServicesAddingUserQueue,
            exchange: RabbitMQConstants.AuthAddExchange,
            routingKey: RabbitMQConstants.MedicalServicesAddingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var userResponse = JsonConvert.DeserializeObject<ApplicationUserResponse>(UserDecoded);
            var mapper = (IMapper) serviceProvider.GetRequiredService(typeof(IMapper))!;
            var userCommand = mapper.Map<AddUserCommand>(userResponse!);
            var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
            var result = await mediator.Send(userCommand!);
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
            queue: RabbitMQConstants.MedicalServicesAddingUserQueue,
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
            autoDelete: false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalServicesDeletingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalServicesDeletingUserQueue,
            exchange: RabbitMQConstants.AuthDeleteExchange,
            routingKey: RabbitMQConstants.MedicalServicesDeletingUserQueue
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
                Logging(logger, result.Errors);
            }
            else
            {
                logger.Information(result.Value.Message);
            }
        };
        channel.BasicConsume(
            queue: RabbitMQConstants.MedicalServicesDeletingUserQueue,
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
            autoDelete: false
        );

        channel.QueueDeclare(
            queue: RabbitMQConstants.MedicalServicesUpdatingUserQueue,
            durable: true,
            exclusive: false,
            autoDelete: false
        );

        channel.QueueBind(
            queue: RabbitMQConstants.MedicalServicesUpdatingUserQueue,
            exchange: RabbitMQConstants.AuthUpdateExchange,
            routingKey: RabbitMQConstants.MedicalServicesUpdatingUserQueue
        );

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var userEncoded = eventArgs.Body.ToArray();
            var UserDecoded = Encoding.UTF8.GetString(userEncoded);
            var userResponse = JsonConvert.DeserializeObject<ApplicationUserResponse>(UserDecoded);
            var mapper = (IMapper) serviceProvider.GetRequiredService(typeof(IMapper))!;
            var userCommand = mapper.Map<UpdateUserCommand>(userResponse!);
            var mediator = (ISender) serviceProvider.GetRequiredService(typeof(ISender))!;
            var result = await mediator.Send(userCommand!);
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
            queue: RabbitMQConstants.MedicalServicesUpdatingUserQueue,
            autoAck: false,
            consumer: consumer
        );
        return Task.CompletedTask;
    }
    private static void Logging (ILogger _logger, List<Error> errors)
    {
        
            _logger.Error(@$"An error has been occured..
                UserId: RabitMQ
                Called Method: 
                TraceId: 
                Errors: [{string.Join(", ", errors.Select(error => error.Description))}]");
    }
}
