namespace BloodDonation.Application.BloodDonation.Common;

public record DonationResponse(
    UserResponse Requester,
    UserResponse? Donor,
    string Id,
    string BloodType,
    string Locatoin,
    string Reason,
    string Status);