using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;
namespace MedicalServices.Application.MedicalServices.Clinics.Commands.DeleteClinicAddress;


public class DeleteClinicAddressCommandHandler : IRequestHandler<DeleteClinicAddressCommand, ErrorOr<CommandResponse>>
{
    private readonly IClinicAddressRepository _clinicAddressRepository;
    public DeleteClinicAddressCommandHandler(
        IClinicAddressRepository clinicAddressRepository)
    {
        _clinicAddressRepository = clinicAddressRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(DeleteClinicAddressCommand command, CancellationToken cancellationToken)
    {
        var clinicAddress =  (await _clinicAddressRepository.GetByIdAsync(command.ClinicAddressId));
        if (clinicAddress == null)
            return Errors.ClinicAddress.NotFound;
        
        if (clinicAddress.OwnerId != command.DoctorId)
            return Errors.User.YouCanNotDoThis;
        _clinicAddressRepository.Remove(clinicAddress);
        if (await _clinicAddressRepository.SaveAsync() == 0)
            return Errors.ClinicAddress.DeleteFailed;
            
        return new CommandResponse(
            true,
            "ClinicAddress deleted successfully.",
            $"clinics/{clinicAddress.ClinicId}/addresses/page-number/1");
    }
}