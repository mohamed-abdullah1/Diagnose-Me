using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.DeleteClinic;


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
        
        _clinicRepository.Remove(clinic);
        if (await _clinicRepository.SaveAsync() == 0)
            return Errors.Clinic.DeleteFailed;
        return new CommandResponse(
            true,
            "Clinic deleted successfully.",
            $"clinics/page-number/1");
        
    }
}