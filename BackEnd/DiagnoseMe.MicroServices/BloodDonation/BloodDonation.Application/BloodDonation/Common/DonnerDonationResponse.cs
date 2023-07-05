namespace BloodDonation.Application.BloodDonation.Common;

public record DonnerDonationResponse(
    UserResponse Donner,
    string Status,
    UserResponse Requester,
    string DonationRequestId);