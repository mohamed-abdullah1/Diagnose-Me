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
    private readonly IDonnerDonationRequestRepository _donnerDonationRequestRepository;
    private readonly IMessageQueueManager _messageQueueManager;


    public AcceptDonationCommandHandler(
        IDonationRequestRepository donationRequestRepository,
        IUserRepository userRepository,
        IDonnerDonationRequestRepository donnerDonationRequestRepository,
        IMessageQueueManager messageQueueManager)
    {
        _donationRequestRepository = donationRequestRepository;
        _userRepository = userRepository;
        _donnerDonationRequestRepository = donnerDonationRequestRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AcceptDonationCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user is null)
            return Errors.User.NotFound;

        var donationRequest = (await _donationRequestRepository.Get(
            predicate: x => x.Id == command.Id)).FirstOrDefault();

        if (donationRequest is null)
            return Errors.DonationRequest.NotFound;

        if (user.BloodType != donationRequest.BloodType)
            return Errors.DonationRequest.InvalidBloodType;
        
        if (donationRequest.RequesterId == user.Id)
            return Errors.User.YouCanNotDoThis;

        if(user.LastDonationDate!.Value.AddDays(90) > DateTime.Now)
            return Errors.User.YouCanNotDoThis;

        if (donationRequest.Status == DonationRequestStatus.Pending )
        {
            var donnerDonationRequest = new DonnerDonationRequest{
                DonnerId = user.Id!,
                DonationRequestId = donationRequest.Id!,
                Status = DonationRequestStatus.Accepted,
                Donner = user,
                DonationRequest = donationRequest
            };
            donationRequest.Donners.Add(user);
            await _donationRequestRepository.Edit(donationRequest);
            await _donnerDonationRequestRepository.AddAsync(donnerDonationRequest);
            
            if(await _donationRequestRepository.SaveAsync() == 0)
                return Errors.DonationRequest.SaveFailed;
            
            _messageQueueManager.PublishNotification( new NotificationResponse(
                Title: "Donation request accepted",
                SenderId: user.Id!,
                RecipientId: donationRequest.RequesterId,
                Message: $"Your donation request has been accepted by {user.FullName}."
            ));
            return new CommandResponse(
                Message: "Donation request accepted.",
                Success: true,
                Path: $"api/donation-request/{donationRequest.Id}"
            );
        }

        return Errors.DonationRequest.InvalidStatus;
    }
}