using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.Authentication.Users.Commands.AddUser;


public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ErrorOr<CommandResponse>>
{
    private readonly IUserRepository _userRepository;
    public AddUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.Id);
        if (user != null)
        {
            return Errors.User.AlreadyExists;
        }

        user = new User{
            Id = command.Id,
            Name = command.Name,
            FullName = command.FullName,
            ProfilePictureUrl = command.ProfilePictureUrl,
            IsDoctor = command.IsDoctor
        };
        
        await _userRepository.AddAsync(user);
        if (await _userRepository.SaveAsync(cancellationToken) == 0)
        {
            return Errors.User.AddFailed;
        }

        return new CommandResponse(
            Success: true,
            Message: "User added successfully.",
            Path: "AddUserCommandHandler"
        );
    }
}