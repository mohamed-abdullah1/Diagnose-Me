using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.AddPatient;


public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, ErrorOr<CommandResponse>>
{
    private readonly IPatientRepository _patientRepository;
    public AddPatientCommandHandler(
        IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddPatientCommand command, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(command.Id);
        if (patient != null)
            return Errors.Patient.AlreadyExists;
        patient = new Patient
        {
            Id = command.Id,
            Height = command.Height,
            Weight = command.Weight
        };

        await _patientRepository.AddAsync(patient);

        if (await _patientRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Patient.AddFailed;

        return new CommandResponse(
            Success: true,
            Message: "Patient added successfully.",
            Path: $"Patients/{command.Id}"
        );
    }
}