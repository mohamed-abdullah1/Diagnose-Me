using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Application.Common.Interfaces.Persistence;
using BloodDonation.Domain.Common.DonationRequestStatus;
using BloodDonation.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Commands.RequestDonation;

public class RequestDonationCommandHandler : IRequestHandler<RequestDonationCommand, ErrorOr<CommandResponse>>
{
    private readonly IDonationRequestRepository _bloodDonationRepository;
    private readonly IUserRepository _userRepository;
    public RequestDonationCommandHandler(
        IDonationRequestRepository bloodDonationRepository,
        IUserRepository userRepository)
    {
        _bloodDonationRepository = bloodDonationRepository;
        _userRepository = userRepository;
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
            Location = command.Location,
            Reason = command.Reason,
            RequesterId = command.RequesterId,
            Status = DonationRequestStatus.Pending
        };
        await _bloodDonationRepository.AddAsync(donationRequest);
        return new CommandResponse(
            true,
            "Donation request created",
            $"donation-request/{donationRequest.Id}");
    }

}