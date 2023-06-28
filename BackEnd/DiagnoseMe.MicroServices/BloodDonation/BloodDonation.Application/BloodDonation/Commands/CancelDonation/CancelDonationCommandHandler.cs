using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using BloodDonation.Domain.Common.Errors;
using BloodDonation.Domain.Common.DonationRequestStatus;
using BloodDonation.Application.Common.Interfaces.RabbitMQ;

namespace BloodDonation.Application.BloodDonation.Commands.CancelDonation;

public class CancelDonationCommandHandler : IRequestHandler<CancelDonationCommand, ErrorOr<CommandResponse>>
{
    private readonly IDonationRequestRepository _donationRequestRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageQueueManager _messageQueueManager;

    public CancelDonationCommandHandler(
        IDonationRequestRepository donationRequestRepository,
        IUserRepository userRepository,
        IMessageQueueManager messageQueueManager)
    {
        _donationRequestRepository = donationRequestRepository;
        _userRepository = userRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(CancelDonationCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user is null)
            return Errors.User.NotFound;

        var bloodDonation = (await _donationRequestRepository.Get(
            predicate: x => x.Id == command.Id)).FirstOrDefault();

        if (bloodDonation is null)
            return Errors.DonationRequest.NotFound;

        if (bloodDonation.RequesterId == user.Id)
        {
            bloodDonation.Status = DonationRequestStatus.Canceled;
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request canceled",
                SenderId: user.Id!,
                RecipientId: bloodDonation.DonnerId,
                Message: $"The donation request {bloodDonation.Id} has been canceled by {user.FullName}."
            ));
        }
            
        else if (bloodDonation.DonnerId == user.Id)
        {
            bloodDonation.Status = DonationRequestStatus.Canceled;
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request canceled",
                SenderId: user.Id!,
                RecipientId: bloodDonation.RequesterId,
                Message: $"The user {user.FullName} has canceled the donation request {bloodDonation.Id}"
            ));
        }
        else
            return Errors.User.YouCanNotDoThis;
        
        await _donationRequestRepository.Edit(bloodDonation);
        return new CommandResponse(
            Message: "Donation request canceled.",
            Success: true,
            Path: $"api/donation-request/{bloodDonation.Id}"
        );

    }
}