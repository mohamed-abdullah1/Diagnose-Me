using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;


namespace MedicalServices.Application.Authentication.Users.Commands.UpdateUser;


public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<CommandResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    
    public UpdateUserCommandHandler(
        IUserRepository userRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository)
    {
        _userRepository = userRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
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

        if(user.IsDoctor && user.Doctor == null)
        {
            user.Patient = null;
        }
        else if(!user.IsDoctor && user.Patient == null){
            user.Doctor = null;
        }
        
        await _userRepository.Edit(user);

        await _userRepository.SaveAsync(cancellationToken);
        
        if(user.IsDoctor && user.Doctor == null)
        {
            
            var doctor = new Doctor{
                Id = user.Id,
                User = user
            };
            await  _doctorRepository.AddAsync(doctor);
        }
        else if(!user.IsDoctor && user.Patient == null){
            var patient = new Patient{
                Id = user.Id,
                User = user
            };
            await _patientRepository.AddAsync(patient);
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