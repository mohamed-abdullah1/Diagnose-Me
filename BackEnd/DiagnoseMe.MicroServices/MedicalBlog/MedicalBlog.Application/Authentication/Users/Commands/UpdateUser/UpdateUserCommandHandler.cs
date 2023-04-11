using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.Authentication.Users.Commands.UpdateUser;


public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<CommandResponse>>
{
    private readonly IUserRepository _userRepository;
    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.Id);
        if (user == null)
            return Errors.User.NotFound;
        
        user.Name = command.Name;
        user.FullName = command.FullName;
        user.ProfilePictureUrl = command.ProfilePictureUrl;

        if (await _userRepository.SaveAsync(cancellationToken) == 0)
            return Errors.User.UpdateFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "User updated successfully.",
            Path: "UpdateUserCommandHandler"
        );
    }
}