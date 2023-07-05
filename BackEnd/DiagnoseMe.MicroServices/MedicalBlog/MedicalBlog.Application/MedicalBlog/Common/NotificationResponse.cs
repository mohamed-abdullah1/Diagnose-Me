namespace MedicalBlog.Application.MedicalBlog.Common;

public record NotificationResponse(
    string Title,
    string SenderId,
    string RecipientId,
    string Message);