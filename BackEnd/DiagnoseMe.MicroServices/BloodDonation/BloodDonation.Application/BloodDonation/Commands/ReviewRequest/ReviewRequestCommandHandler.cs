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
        var donationRequest = (await _donationRequestRepository.Get(
            predicate: x => x.Id == command.Id)).FirstOrDefault();

        if (donationRequest is null)
            return Errors.DonationRequest.NotFound;

        if (donationRequest.Status != DonationRequestStatus.UnderReview)
            return Errors.DonationRequest.InvalidStatus;

        if (command.IsAccepted)
        {
            donationRequest.Status = DonationRequestStatus.Pending;
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request Pending",
                SenderId: command.UserId,
                RecipientId: donationRequest.RequesterId,
                Message: $"Your donation request is accepted from admin and is pending for donners."
            ));
        }
        else
        {
            donationRequest.Status = DonationRequestStatus.Rejected;
            var reason = command.Reason ?? "it is not applicable.";
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request rejected",
                SenderId: command.UserId,
                RecipientId: donationRequest.RequesterId,
                Message: $"The admin has rejected your donation request because {reason}."
            ));
        }

        await _donationRequestRepository.Edit(donationRequest);
        if(await _donationRequestRepository.SaveAsync() == 0)
            return Errors.DonationRequest.SaveFailed;
        return new CommandResponse(
            Message: "Donation request reviewed.",
            Success: true,
            Path: $"donation-request/{donationRequest.Id}"
        );
    }


}