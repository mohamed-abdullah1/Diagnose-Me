using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Common;

public record QuestionResponse(
    string Id,
    string QuestionString,
    UserData AskingUser,
    string CreatedOn,
    string? ModifiedOn,
    int AnswersCount,
    List<string>? Tags,
    int AgreementCount,
    int DisagreementCount);