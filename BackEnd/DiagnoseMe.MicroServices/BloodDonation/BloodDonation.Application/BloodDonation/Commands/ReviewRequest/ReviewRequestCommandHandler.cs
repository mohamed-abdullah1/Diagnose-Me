using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using BloodDonation.Application.Common.Interfaces.RabbitMQ;
using ErrorOr;
using MediatR;
using BloodDonation.Domain.Common.DonationRequestStatus;
using BloodDonation.Domain.Common.Errors;


namespace BloodDonation.Application.BloodDonation.Commands.ReviewRequest;

public class ReviewRequestCommandHandler : IRequestHandler<ReviewRequestCommand, ErrorOr<CommandResponse>>
{
    private readonly IDonationRequestRepository _donationRequestRepository;
    private readonly IMessageQueueManager _messageQueueManager;

    public ReviewRequestCommandHandler(
        IDonationRequestRepository donationRequestRepository,
        IMessageQueueManager messageQueueManager)
    {
        _donationRequestRepository = donationRequestRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(ReviewRequestCommand command, CancellationToken cancellationToken)
    {
        var bloodDonation = (await _donationRequestRepository.Get(
            predicate: x => x.Id == command.Id)).FirstOrDefault();

        if (bloodDonation is null)
            return Errors.DonationRequest.NotFound;

        if (bloodDonation.Status != DonationRequestStatus.UnderReview)
            return Errors.DonationRequest.InvalidStatus;

        if (command.IsAccepted)
        {
            bloodDonation.Status = DonationRequestStatus.Completed;
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request completed",
                SenderId: bloodDonation.DonnerId,
                RecipientId: bloodDonation.RequesterId,
                Message: $"The user {bloodDonation.Donner!.FullName} has confirmed the donation request {bloodDonation.Id} as completed."
            ));
        }
        else
        {
            bloodDonation.Status = DonationRequestStatus.Accepted;
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request accepted",
                SenderId: bloodDonation.DonnerId,
                RecipientId: bloodDonation.RequesterId,
                Message: $"The user {bloodDonation.Donner!.FullName} has rejected the donation request {bloodDonation.Id}."
            ));
        }

        await _donationRequestRepository.Edit(bloodDonation);
        return new CommandResponse(
            Message: "Donation request reviewed.",
            Success: true,
            Path: $"donation-request/{bloodDonation.Id}"
        );
    }


}