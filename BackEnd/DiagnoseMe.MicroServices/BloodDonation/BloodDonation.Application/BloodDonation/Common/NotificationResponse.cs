namespace BloodDonation.Application.BloodDonation.Common;

public record NotificationResponse(
    string SenderId,
    string RecipientId,
    string Message);