namespace BloodDonation.Application.BloodDonation.Common;

public record NotificationResponse(
    string Title,
    string SenderId,
    string RecipientId,
    string Message);