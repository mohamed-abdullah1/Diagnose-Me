using BloodDonation.Application.BloodDonation.Common;
using ErrorOr;
using MediatR;

namespace BloodDonation.Application.BloodDonation.Commands.RequestDonation;


public record RequestDonationCommand(
    string BloodType,
    string Type,
    string Location,
    string Reason,
    string RequesterId) : IRequest<ErrorOr<CommandResponse>>;