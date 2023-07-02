using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Commands.Ask;

public record AskCommand(
    string AskingUserId,
    string QuestionString,
    List<string> Tags): IRequest<ErrorOr<CommandResponse>>;