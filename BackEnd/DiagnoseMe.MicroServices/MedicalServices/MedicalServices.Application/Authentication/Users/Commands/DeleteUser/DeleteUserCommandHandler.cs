using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.Authentication.Users.Commands.DeleteUser;


public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<CommandResponse>>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.Id);
        if (user == null)
        {
            return Errors.User.NotFound;
        }

        _userRepository.Remove(user);
        if (await _userRepository.SaveAsync(cancellationToken) == 0)
        {
            return Errors.User.DeleteFailed;
        }

        return new CommandResponse(
            Success: true,
            Message: "User deleted successfully.",
            Path: "DeleteUserCommandHandler"
        );
    }
}