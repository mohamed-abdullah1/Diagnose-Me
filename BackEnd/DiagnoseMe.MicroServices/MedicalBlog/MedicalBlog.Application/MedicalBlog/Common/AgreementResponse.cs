namespace MedicalBlog.Application.MedicalBlog.Common;

public record AgreementResponse(
    bool IsAgreed,
    UserData User
);