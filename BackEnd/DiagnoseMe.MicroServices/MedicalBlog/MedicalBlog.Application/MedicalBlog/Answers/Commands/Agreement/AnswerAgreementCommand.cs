using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Answers.Commands.Agreement;

public record AnswerAgreementCommand(string AnswerId, string UserId, bool IsAgreed) : IRequest<ErrorOr<CommandResponse>>;