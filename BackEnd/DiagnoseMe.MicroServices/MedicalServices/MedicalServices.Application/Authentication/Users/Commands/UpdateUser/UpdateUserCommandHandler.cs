using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.Authentication.Users.Commands.UpdateUser;


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
        user.IsDoctor = command.IsDoctor;

        if (await _userRepository.SaveAsync(cancellationToken) == 0)
            return Errors.User.UpdateFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "User updated successfully.",
            Path: "UpdateUserCommandHandler"
        );
    }
}