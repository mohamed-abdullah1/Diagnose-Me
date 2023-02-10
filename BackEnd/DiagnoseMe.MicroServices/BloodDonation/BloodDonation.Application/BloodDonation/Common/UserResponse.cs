namespace BloodDonation.Application.BloodDonation.Common;

public record UserResponse(
    string Id,
    string FullName,
    string ProfilePictureUrl,
    string BloodType);