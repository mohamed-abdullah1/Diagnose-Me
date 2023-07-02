using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.Doctors.Commands.UpdateDoctor;


public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, ErrorOr<CommandResponse>>
{

    private readonly IUserRepository _userRepository;
    public UpdateDoctorCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
    {
        var doctor = await _userRepository.GetByIdAsync(command.Id);
        if (doctor is null)
            return Errors.User.NotFound;
        
        doctor.Rating = command.Rating;

        await _userRepository.Edit(doctor);

        if(await _userRepository.SaveAsync(cancellationToken) == 0)
            return Errors.User.UpdateFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "Doctor Successfully Updated",
            Path: ""
        );
    }
}