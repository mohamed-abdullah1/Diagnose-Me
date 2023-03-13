using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.SubscribeDoctor;

public record SubscribeDoctorCommand(
    string DoctorId,
    string UserId) : IRequest<ErrorOr<CommandResponse>>;