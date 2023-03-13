using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.DeleteClinic;


public class DeleteClinicCommandHandler : IRequestHandler<DeleteClinicCommand, ErrorOr<CommandResponse>>
{
    private readonly IClinicRepository _clinicRepository;
    public DeleteClinicCommandHandler(
        IClinicRepository clinicRepository)
    {
        _clinicRepository = clinicRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(DeleteClinicCommand command, CancellationToken cancellationToken)
    {
        var clinic =  (await _clinicRepository.GetByIdAsync(command.ClinicId));
        if (clinic == null)
            return Errors.Clinic.NotFound;
        try{
            _clinicRepository.Remove(clinic);
            await _clinicRepository.Save();
            return new CommandResponse(
                true,
                "Clinic deleted successfully.",
                $"clinics/page-number/1");
        }
        catch (Exception)
        {
            return Errors.Clinic.DeleteFailed;
        }
    }
}