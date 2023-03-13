using MedicalBlog.Application.MedicalBlog.Answers.Common;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Common;

public record QuestionResponse(
    string Id,
    string QuestionString,
    UserData AskingUser,
    string CreatedOn,
    string? ModifiedOn,
    List<AnswerResponse>? Answers,
    int AnswersCount
);