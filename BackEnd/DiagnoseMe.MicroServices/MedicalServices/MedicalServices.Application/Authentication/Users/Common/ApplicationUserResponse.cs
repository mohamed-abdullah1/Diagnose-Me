namespace MedicalServices.Application.Authentication.Users.Common;

public record ApplicationUserResponse(
    string Id,
    string Name,
    string FullName,
    string Gender,
    string DateOfBirth,
    string BloodType,
    string ProfilePictureUrl,
    string PhoneNumber,
    string NationalID,
    bool IsDoctor
);