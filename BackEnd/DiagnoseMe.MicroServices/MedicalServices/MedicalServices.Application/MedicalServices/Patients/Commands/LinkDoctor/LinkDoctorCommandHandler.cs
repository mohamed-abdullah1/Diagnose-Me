using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.LinkDoctor;


public class LinkDoctorCommandHandler : IRequestHandler<LinkDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IPatientDoctorRepository _patientDoctorRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;

    public LinkDoctorCommandHandler(
        IPatientDoctorRepository patientDoctorRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository)
    {
        _patientDoctorRepository = patientDoctorRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(LinkDoctorCommand command, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(command.Id);
        if (patient == null)
            return Errors.Patient.NotFound;

        var doctor = await _doctorRepository.GetByIdAsync(command.DoctorId);
        if (doctor == null)
            return Errors.Doctor.NotFound;

        var patientDoctor = await _patientDoctorRepository.GetByIdAsync(new {command.Id, command.DoctorId});
        if (patientDoctor != null)
            return Errors.PatientDoctor.AlreadyLinked;

        patientDoctor = new PatientDoctor{
            PatientId = command.Id,
            DoctorId = command.DoctorId
        };
        patientDoctor.Patient = patient;
        patientDoctor.Doctor = doctor;
        
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