namespace Auth.Application.MedicalBlog.Common;

public record NotificationResponse(
    string SenderId,
    string RecipientId,
    string Message);