using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.LinkDoctor;


public class LinkDoctorCommandHandler : IRequestHandler<LinkDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IPatientDoctorRepository _patientDoctorRepository;

    public LinkDoctorCommandHandler(
        IPatientDoctorRepository patientDoctorRepository)
    {
        _patientDoctorRepository = patientDoctorRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(LinkDoctorCommand command, CancellationToken cancellationToken)
    {
        var patientDoctor = await _patientDoctorRepository.GetByIdAsync(new {command.Id, command.DoctorId});
        if (patientDoctor != null)
            return Errors.PatientDoctor.AlreadyLinked;

        patientDoctor = new PatientDoctor{
            PatientId = command.Id,
            DoctorId = command.DoctorId
        };
        await _patientDoctorRepository.AddAsync(patientDoctor);
        if (await _patientDoctorRepository.SaveAsync(cancellationToken) == 0)
            return Errors.PatientDoctor.AddFailed;

        return new CommandResponse(
            Success: true,
            Message: "Doctor linked successfully.",
            Path: $"Patients/{command.Id}"
        );
    }
}