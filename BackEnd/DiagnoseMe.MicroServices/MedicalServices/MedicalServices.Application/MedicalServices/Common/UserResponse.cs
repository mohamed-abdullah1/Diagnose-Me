namespace MedicalServices.Application.MedicalServices.Common;

public record UserResponse(
    string Id,
    string Name,
    string FullName,
    string ProfilePictureUrl
    );