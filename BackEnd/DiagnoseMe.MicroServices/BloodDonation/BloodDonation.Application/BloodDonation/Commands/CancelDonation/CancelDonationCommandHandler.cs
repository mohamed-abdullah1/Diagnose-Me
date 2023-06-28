using System.Linq;
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
    private readonly IDonnerDonationRequestRepository _donnerDonationRequestRepository;

    public CancelDonationCommandHandler(
        IDonationRequestRepository donationRequestRepository,
        IUserRepository userRepository,
        IDonnerDonationRequestRepository donnerDonationRequestRepository,
        IMessageQueueManager messageQueueManager)
    {
        _donationRequestRepository = donationRequestRepository;
        _userRepository = userRepository;
        _messageQueueManager = messageQueueManager;
        _donnerDonationRequestRepository = donnerDonationRequestRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(CancelDonationCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user is null)
            return Errors.User.NotFound;

        var donationRequest = (await _donationRequestRepository.Get(
            predicate: x => x.Id == command.Id,
            include: "Donners,Requester"
            )).FirstOrDefault();

        if (donationRequest is null)
            return Errors.DonationRequest.NotFound;

        if (donationRequest.RequesterId == user.Id)
        {
            donationRequest.Status = DonationRequestStatus.Canceled;
            var donnerDonationRequests = (await _donnerDonationRequestRepository.Get(
                predicate: x => x.DonationRequestId == donationRequest.Id
            )).ToList();
            foreach (var donnerDonationRequest in donnerDonationRequests)
            {
                donnerDonationRequest.Status = DonationRequestStatus.Canceled;
                await _donnerDonationRequestRepository.Edit(donnerDonationRequest);
            }

            foreach( var donner in donationRequest.Donners)
            {
                _messageQueueManager.PublishNotification( new NotificationResponse(
                    Title: "Donation request canceled",
                    SenderId: user.Id!,
                    RecipientId: donner.Id!,
                    Message: $"The donation request {donationRequest.Id} has been canceled by {user.FullName}."
                ));
            }
        }
            
        else if (donationRequest.Donners.Select(x => x.Id).Contains(user.Id))
        {
            var donnerDonationRequest = (await _donnerDonationRequestRepository.GetByIdAsync( new {DonnerId = user.Id, DonationRequestId = donationRequest.Id}));
            if (donnerDonationRequest is null)
                return Errors.DonationRequest.NotFound;
            
            donnerDonationRequest.Status = DonationRequestStatus.Canceled;
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request canceled",
                SenderId: user.Id!,
                RecipientId: donationRequest.RequesterId,
                Message: $"The user {user.FullName} has canceled the donation request {donationRequest.Id}"
            ));
            await _donnerDonationRequestRepository.Edit(donnerDonationRequest);
            donationRequest.Donners.Remove(user);
        }
        else
            return Errors.User.YouCanNotDoThis;
        
        await _donationRequestRepository.Edit(donationRequest);
        
        if (await _donationRequestRepository.SaveAsync() == 0)
            return Errors.DonationRequest.SaveFailed;

        return new CommandResponse(
            Message: "Donation request canceled.",
            Success: true,
            Path: $"api/donation-request/{donationRequest.Id}"
        );

    }
}