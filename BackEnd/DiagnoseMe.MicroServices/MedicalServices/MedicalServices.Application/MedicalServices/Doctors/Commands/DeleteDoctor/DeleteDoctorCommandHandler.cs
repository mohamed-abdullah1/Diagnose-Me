using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.DeleteDoctor;


public class DeleteDoctorCommandHandler: IRequestHandler<DeleteDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IDoctorRepository _doctorRepository;
    public DeleteDoctorCommandHandler(
        IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(DeleteDoctorCommand command, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByIdAsync(command.DoctorId);
        if (doctor == null)
            return Errors.Doctor.NotFound;
        
        _doctorRepository.Remove(doctor);
        if (await _doctorRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Doctor.DeleteFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "Doctor deleted successfully.",
            Path: $"Doctors"
        );
    }
}
