using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.UpdateClinic;

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
        try{
            await _clinicRepository.Edit(clinic);
            await _clinicRepository.Save();
            return new CommandResponse(
                true,
                "Clinic updated successfully.",
                $"clinics/{clinic.Id}");
        }
        catch (Exception)
        {
            return Errors.Clinic.UpdateFailed;
        }
    }
}