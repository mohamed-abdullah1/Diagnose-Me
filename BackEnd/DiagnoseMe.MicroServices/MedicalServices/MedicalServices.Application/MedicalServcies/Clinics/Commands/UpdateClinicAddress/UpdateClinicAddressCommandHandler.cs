using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.UpdateClinicAddress;

public class UpdateClinicAddressCommandHandler : IRequestHandler<UpdateClinicAddressCommand, ErrorOr<CommandResponse>>
{
    private readonly IClinicAddressRepository _clinicAddressRepository;
    public UpdateClinicAddressCommandHandler(
        IClinicAddressRepository clinicAddressRepository)
    {
        _clinicAddressRepository = clinicAddressRepository;
    }

    public async Task<ErrorOr<CommandResponse>>  Handle(UpdateClinicAddressCommand command, CancellationToken cancellationToken)
    {
        var clinicAddress =  (await _clinicAddressRepository.GetByIdAsync(command.ClinicAddressId));
        if (clinicAddress == null)
            return Errors.ClinicAddress.NotFound;
        
        if (clinicAddress.OwnerId != command.DoctorId)
            return Errors.User.YouCanNotDoThis;
        
        clinicAddress.Name = command.Name;
        clinicAddress.Street = command.Street;
        clinicAddress.City = command.City;
        clinicAddress.State = command.State;
        clinicAddress.Country = command.Country;
        clinicAddress.ZipCode = command.ZipCode;
        clinicAddress.OpenTime = TimeOnly.ParseExact(command.OpenTime, "HH:mm");
        clinicAddress.CloseTime = TimeOnly.ParseExact(command.CloseTime, "HH:mm");
        await _clinicAddressRepository.Edit(clinicAddress);
        
        if (await _clinicAddressRepository.SaveAsync() == 0)
            return Errors.ClinicAddress.UpdateFailed;

        return new CommandResponse(
            true,
            "Clinic address updated successfully.",
            $"clinics/{clinicAddress.ClinicId}/addresses/address-id/{clinicAddress.Id}");
    }   

}