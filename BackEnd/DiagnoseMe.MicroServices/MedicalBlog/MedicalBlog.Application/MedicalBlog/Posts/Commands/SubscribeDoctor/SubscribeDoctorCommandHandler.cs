using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.Common.Interfaces.RabbitMQ;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.SubscribeDoctor;

public class SubscribeDoctorCommandHandler : IRequestHandler<SubscribeDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMessageQueueManager _messageQueueManager;
    
    public SubscribeDoctorCommandHandler(
        IUserRepository userRepository,
        IMessageQueueManager messageQueueManager)
    {
        _userRepository = userRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(SubscribeDoctorCommand command, CancellationToken cancellationToken)
    {
        var doctor = (await _userRepository.Get(
            predicate: x => x.Id == command.DoctorId,
            include: "Subscribers"))
            .FirstOrDefault();

        if (doctor == null)
            return Errors.User.DoctorNotFound;
        
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;
        
        if (doctor.Id == user.Id)
            return Errors.User.YouCanNotDoThis;
        
        var ifSubscribed = doctor.Subscribers.Any(x => x.Id == user.Id);
        if (ifSubscribed)
        {
            doctor.Subscribers.Remove(user);
        }
        else{
            doctor.Subscribers.Add(user);
        }


        await _userRepository.Edit(doctor);
        
        if (await _userRepository.SaveAsync() == 0)
            return Errors.User.FailedToSubscribe;
        if(ifSubscribed)
            _messageQueueManager.PublishNotification(new NotificationResponse(
                SenderId:user.Id!,
                RecipientId:doctor.Id!,
                Message: $"User {user.Name} has started to subscribe you."));
        var message = ifSubscribed ? "subscribed" : "unsubscribed";
        return new CommandResponse(
            true,
            $"You have successfully {message} to this doctor with id {command.DoctorId}.",
            null!);

    }
}