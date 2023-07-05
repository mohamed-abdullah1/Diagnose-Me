using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Answers.Commands.AddAnswer;

public record AnswerCommand(
    string AnsweringDoctorId,
    string QuestionId,
    string AnswerString
) : IRequest<ErrorOr<CommandResponse>>;