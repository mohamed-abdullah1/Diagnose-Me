namespace BloodDonation.Application.BloodDonation.Common;

public record DonationResponse(
    UserResponse Requester,
    List<DonnerDonationResponse> DonnerDonationResponses,
    string Id,
    string BloodType,
    string Locatoin,
    string Reason,
    string Status);