using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Patients.Commands.AddPatient;


public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, ErrorOr<CommandResponse>>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUserRepository _userRepository;
    public AddPatientCommandHandler(
        IPatientRepository patientRepository,
        IUserRepository userRepository)
    {
        _patientRepository = patientRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddPatientCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.Id);
        if (user == null)
            return Errors.User.NotFound;

        var patient = await _patientRepository.GetByIdAsync(command.Id);
        if (patient != null)
            return Errors.Patient.AlreadyExists;
            
        patient = new Patient
        {
            Id = command.Id,
            Height = command.Height,
            Weight = command.Weight
        };
        patient.User = user;

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