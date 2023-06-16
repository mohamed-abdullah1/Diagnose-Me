using ErrorOr;
using MediatR;
using MedicalBlog.Application.MedicalBlog.Common;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.UnSavePost; 

public record UnSavePostCommand(
    string UserId,
    string PostId
) : IRequest<ErrorOr<CommandResponse>>;