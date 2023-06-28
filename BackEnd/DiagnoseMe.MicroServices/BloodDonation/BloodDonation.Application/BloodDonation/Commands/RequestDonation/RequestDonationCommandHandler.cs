using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using BloodDonation.Application.Common.Interfaces.RabbitMQ;
using BloodDonation.Domain.Common.DonationRequestStatus;
using BloodDonation.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Commands.RequestDonation;

public class RequestDonationCommandHandler : IRequestHandler<RequestDonationCommand, ErrorOr<CommandResponse>>
{
    private readonly IDonationRequestRepository _donationRequestRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageQueueManager _messageQueueManager;
    public RequestDonationCommandHandler(
        IDonationRequestRepository donationRequestRepository,
        IMessageQueueManager messageQueueManager,
        IUserRepository userRepository)
    {
        _donationRequestRepository = donationRequestRepository;
        _userRepository = userRepository;
        _messageQueueManager = messageQueueManager;
    }
    public async Task<ErrorOr<CommandResponse>> Handle(RequestDonationCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.RequesterId);
        if (user == null)
        {
            return Errors.User.NotFound;
        }
        var donationRequest = new DonationRequest{
            Id = Guid.NewGuid().ToString(),
            BloodType = command.BloodType,
            Type = command.Type,
            Location = command.Location,
            Reason = command.Reason,
            RequesterId = command.RequesterId,
            Status = DonationRequestStatus.UnderReview
        };

        donationRequest.Requester = user;
        var usersIdWithSameBloodType = (await _userRepository.Get(
            predicate: x => x.BloodType == command.BloodType)).Select(x => x.Id).ToList();
        
        foreach (var userId in usersIdWithSameBloodType)
        {
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "New donation request",
                SenderId: user.Id!,
                RecipientId: userId!,
                Message: $"A donation request has been created by {user.FullName} with the same blood type as yours. Do you want to accept it?"
            ));
        }
        await _donationRequestRepository.AddAsync(donationRequest);
        return new CommandResponse(
            true,
            "Donation request created",
            $"donation-request/{donationRequest.Id}");
    }

}