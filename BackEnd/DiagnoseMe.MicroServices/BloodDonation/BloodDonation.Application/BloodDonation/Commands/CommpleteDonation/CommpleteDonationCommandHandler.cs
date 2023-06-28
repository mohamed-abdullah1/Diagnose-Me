using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using BloodDonation.Domain.Common.Errors;
using BloodDonation.Domain.Common.DonationRequestStatus;
using BloodDonation.Application.Common.Interfaces.RabbitMQ;

namespace BloodDonation.Application.BloodDonation.Commands.CommpleteDonation;

public class CommpleteDonationCommandHandler : IRequestHandler<CommpleteDonationCommand, ErrorOr<CommandResponse>>
{
    private readonly IDonationRequestRepository _donationRequestRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageQueueManager _messageQueueManager;

    public CommpleteDonationCommandHandler(
        IDonationRequestRepository donationRequestRepository,
        IUserRepository userRepository,
        IMessageQueueManager messageQueueManager)
    {
        _donationRequestRepository = donationRequestRepository;
        _userRepository = userRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(CommpleteDonationCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user is null)
            return Errors.User.NotFound;

        var bloodDonation = (await _donationRequestRepository.Get(
            predicate: x => x.Id == command.Id)).FirstOrDefault();

        if (bloodDonation is null)
            return Errors.DonationRequest.NotFound;

        if (bloodDonation.DonnerId == user.Id)
        {
            bloodDonation.Status = DonationRequestStatus.PreCompleted;
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request completed",
                SenderId: user.Id!,
                RecipientId: bloodDonation.RequesterId,
                Message: $"The user {user.FullName} has completed the donation request {bloodDonation.Id} awaiting your confirmation."
            ));
        }
        else if (bloodDonation.RequesterId == user.Id)
        {
            bloodDonation.Status = DonationRequestStatus.Completed;
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request completed",
                SenderId: user.Id!,
                RecipientId: bloodDonation.DonnerId,
                Message: $"The user {user.FullName} has confirmed the donation request {bloodDonation.Id} as completed."
            ));
        }
        else
            return Errors.User.YouCanNotDoThis;
        
        await _donationRequestRepository.Edit(bloodDonation);
        return new CommandResponse(
            Message: "Donation request completed.",
            Success: true,
            Path: $"api/donation-request/{bloodDonation.Id}"
        );

    }
}