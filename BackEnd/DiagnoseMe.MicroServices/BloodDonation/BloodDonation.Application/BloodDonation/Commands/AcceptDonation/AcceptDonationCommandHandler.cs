using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using BloodDonation.Application.Common.Interfaces.RabbitMQ;
using BloodDonation.Domain.Common.DonationRequestStatus;
using BloodDonation.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Commands.AcceptDonation;


public class AcceptDonationCommandHandler : IRequestHandler<AcceptDonationCommand, ErrorOr<CommandResponse>>
{
    private readonly IDonationRequestRepository _donationRequestRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageQueueManager _messageQueueManager;

    public AcceptDonationCommandHandler(
        IDonationRequestRepository donationRequestRepository,
        IUserRepository userRepository,
        IMessageQueueManager messageQueueManager)
    {
        _donationRequestRepository = donationRequestRepository;
        _userRepository = userRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AcceptDonationCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user is null)
            return Errors.User.NotFound;

        var bloodDonation = (await _donationRequestRepository.Get(
            predicate: x => x.Id == command.Id)).FirstOrDefault();

        if (bloodDonation is null)
            return Errors.DonationRequest.NotFound;

        if (user.BloodType != bloodDonation.BloodType)
            return Errors.DonationRequest.InvalidBloodType;
        
        if (bloodDonation.RequesterId == user.Id)
            return Errors.User.YouCanNotDoThis;

        if (bloodDonation.Status == DonationRequestStatus.Pending )
        {
            bloodDonation.Status = DonationRequestStatus.Accepted;
            bloodDonation.DonnerId = user.Id!;
            bloodDonation.Donner = user;
            await _donationRequestRepository.Edit(bloodDonation);
            
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request accepted",
                SenderId: user.Id!,
                RecipientId: bloodDonation.RequesterId,
                Message: $"Your donation request has been accepted by {user.FullName}."
            ));
            return new CommandResponse(
                Message: "Donation request accepted.",
                Success: true,
                Path: $"api/donation-request/{bloodDonation.Id}"
            );
        }

        return Errors.DonationRequest.InvalidStatus;
    }
}