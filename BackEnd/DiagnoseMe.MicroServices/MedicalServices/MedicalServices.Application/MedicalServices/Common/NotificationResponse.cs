namespace MedicalServices.Application.MedicalServices.Common;

public record NotificationResponse(
    string SenderId,
    string RecipientId,
    string Message);