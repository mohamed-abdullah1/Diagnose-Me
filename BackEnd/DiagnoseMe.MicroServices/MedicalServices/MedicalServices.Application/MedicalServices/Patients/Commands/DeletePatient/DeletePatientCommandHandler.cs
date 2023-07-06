using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.DeletePatient;


public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, ErrorOr<CommandResponse>>
{
    private readonly IPatientRepository _patientRepository;
    public DeletePatientCommandHandler(
        IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(DeletePatientCommand command, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(command.Id);
        if (patient == null)
            return Errors.Patient.NotFound;

        _patientRepository.Remove(patient);

        if (await _patientRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Patient.DeleteFailed;

        return new CommandResponse(
            Success: true,
            Message: "Patient deleted successfully.",
            Path: $"Patients"
        );
    }
}