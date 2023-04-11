using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinic;

public class UpdateClinicCommandHandler : IRequestHandler<UpdateClinicCommand, ErrorOr<CommandResponse>>
{
    private readonly IClinicRepository _clinicRepository;
    public UpdateClinicCommandHandler(
        IClinicRepository clinicRepository)
    {
        _clinicRepository = clinicRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdateClinicCommand command, CancellationToken cancellationToken)
    {
        var clinic =  (await _clinicRepository.GetByIdAsync(command.ClinicId));
        if (clinic == null)
            return Errors.Clinic.NotFound;
        clinic.Description = command.Description;
        await _clinicRepository.Edit(clinic);

        if (await _clinicRepository.SaveAsync() == 0)
            return Errors.Clinic.UpdateFailed;

        return new CommandResponse(
            true,
            "Clinic updated successfully.",
            $"clinics/{clinic.Id}");
    }
}