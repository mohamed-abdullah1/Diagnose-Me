using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Domain.Common.Errors;
namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.DeleteClinicAddress;


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
        try{
            _clinicAddressRepository.Remove(clinicAddress);
            await _clinicAddressRepository.Save();
            return new CommandResponse(
                true,
                "ClinicAddress deleted successfully.",
                $"clinics/{clinicAddress.ClinicId}/addresses/page-number/1");
        }
        catch (Exception)
        {
            return Errors.ClinicAddress.DeleteFailed;
        }
    }
}