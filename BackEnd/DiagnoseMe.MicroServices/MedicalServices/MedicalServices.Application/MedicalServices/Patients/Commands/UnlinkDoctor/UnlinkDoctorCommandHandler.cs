using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.UnlinkDoctor;


public class UnlinkDoctorCommandHandler : IRequestHandler<UnlinkDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IPatientDoctorRepository _patientDoctorRepository;
    public UnlinkDoctorCommandHandler(
        IPatientDoctorRepository patientDoctorRepository)
    {
        _patientDoctorRepository = patientDoctorRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UnlinkDoctorCommand command, CancellationToken cancellationToken)
    {
        var patientDoctor = await _patientDoctorRepository.GetByIdAsync(new {command.Id, command.DoctorId});
        if (patientDoctor == null)
            return Errors.PatientDoctor.NotFound;
        
        _patientDoctorRepository.Remove(patientDoctor);
        if (await _patientDoctorRepository.SaveAsync(cancellationToken) == 0)
            return Errors.PatientDoctor.DeleteFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "Doctor unlinked successfully.",
            Path: $"Patients/{command.Id}"
        );
    }
}