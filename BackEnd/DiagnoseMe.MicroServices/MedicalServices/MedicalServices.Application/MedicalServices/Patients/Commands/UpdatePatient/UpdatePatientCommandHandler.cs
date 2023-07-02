using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.UpdatePatient;

public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, ErrorOr<CommandResponse>>
{
    private readonly IPatientRepository _patientRepository;

    public UpdatePatientCommandHandler(
        IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(command.Id);
        if (patient == null)
            return Errors.Patient.NotFound;

        patient.Height = command.Height;
        patient.Weight = command.Weight;

        if (await _patientRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Patient.UpdateFailed;

        return new CommandResponse(
            Success: true,
            Message: "Patient Updateed successfully.",
            Path: $"Patients/{command.Id}"
        );
    }
}