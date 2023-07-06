using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Questions.Commands.Agreement;

public record QuestionAgreementCommand(string QuestionId, string UserId, bool IsAgreed) : IRequest<ErrorOr<CommandResponse>>;