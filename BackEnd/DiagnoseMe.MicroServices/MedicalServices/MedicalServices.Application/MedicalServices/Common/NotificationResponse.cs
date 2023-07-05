namespace MedicalServices.Application.MedicalServices.Common;

public record NotificationResponse(
    string Title,
    string SenderId,
    string RecipientId,
    string Message);