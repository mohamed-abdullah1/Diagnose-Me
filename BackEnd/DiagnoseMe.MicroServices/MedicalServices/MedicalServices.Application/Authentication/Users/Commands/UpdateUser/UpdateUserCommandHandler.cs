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
        var user = (await _userRepository.Get(
            predicate: x => x.Id == command.Id,
            include: "Doctor,Patient")).FirstOrDefault();
        if (user == null)
            return Errors.User.NotFound;
        
        user.Name = command.Name;
        user.FullName = command.FullName;
        user.ProfilePictureUrl = command.ProfilePictureUrl;
        user.IsDoctor = command.IsDoctor;

        if(user.IsDoctor)
        {
            user.Patient = null;
            user.Doctor ??= new Doctor{
                Id = user.Id
            };
        }
        else{
            user.Doctor = null;
            user.Patient ??= new Patient{
                Id = user.Id
            };
        }

        if (await _userRepository.SaveAsync(cancellationToken) == 0)
            return Errors.User.UpdateFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "User updated successfully.",
            Path: "UpdateUserCommandHandler"
        );
    }
}