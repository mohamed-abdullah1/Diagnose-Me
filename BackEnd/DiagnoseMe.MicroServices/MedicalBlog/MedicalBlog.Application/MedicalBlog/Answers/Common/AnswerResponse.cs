using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Answers.Common;

public record AnswerResponse(
    string Id,
    string QuestionId,
    string AnswerString,
    UserData AnsweringDoctor,
    string CreatedOn,
    string? ModifiedOn,
    int AgreementCount,
    int DisagreementCount
);