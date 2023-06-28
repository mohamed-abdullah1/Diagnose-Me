namespace BloodDonation.Application.BloodDonation.Common;

public record DonnerDonationResponse(
    UserResponse Donner,
    string Status,
    string DonationRequestId);