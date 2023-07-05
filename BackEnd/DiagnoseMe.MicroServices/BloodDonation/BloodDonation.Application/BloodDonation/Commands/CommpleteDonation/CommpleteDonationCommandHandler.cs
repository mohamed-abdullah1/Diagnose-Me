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
    private readonly IDonnerDonationRequestRepository _donnerDonationRequestRepository;
    private readonly IMessageQueueManager _messageQueueManager;

    public CommpleteDonationCommandHandler(
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

    public async Task<ErrorOr<CommandResponse>> Handle(CommpleteDonationCommand command, CancellationToken cancellationToken)
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

        if (donationRequest.Donners.Select(x => x.Id).Contains(user.Id))
        {
            var donnerDonationRequest = (await _donnerDonationRequestRepository.GetByIdAsync(
                new {
                    DonnerId = user.Id,
                    DonationRequestId = donationRequest.Id}));
            donnerDonationRequest!.Status = DonationRequestStatus.Completed;
            await _donnerDonationRequestRepository.Edit(donnerDonationRequest);
            if (await _donnerDonationRequestRepository.SaveAsync() == 0)
                return Errors.DonationRequest.SaveFailed;
        }
        
        else if (donationRequest.RequesterId == user.Id)
        {
            donationRequest.Status = DonationRequestStatus.Completed;
            await _donationRequestRepository.Edit(donationRequest);
            if(await _donationRequestRepository.SaveAsync() == 0)
                return Errors.DonationRequest.SaveFailed;
        }
        else
            return Errors.User.YouCanNotDoThis;
        
        
        return new CommandResponse(
            Message: "Donation request completed.",
            Success: true,
            Path: $"api/donation-request/{donationRequest.Id}"
        );

    }
}