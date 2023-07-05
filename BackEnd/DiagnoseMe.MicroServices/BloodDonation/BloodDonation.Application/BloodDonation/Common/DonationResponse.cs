namespace BloodDonation.Application.BloodDonation.Common;

public record DonationResponse(
    UserResponse Requester,
    string Id,
    string BloodType,
    string Locatoin,
    string Type,
    string Reason,
    string Status);