namespace BloodDonation.Application.BloodDonation.Common;

public record CommandResponse(
    bool Success,
    string Message,
    string Path);