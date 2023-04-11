using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.Common.Interfaces.Services;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Helpers;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicAddressProfilePicture;


public class UpdateClinicAddressProfilePictureCommandHandler : IRequestHandler<UpdateClinicAddressProfilePictureCommand, ErrorOr<CommandResponse>>
{
    private readonly IClinicAddressRepository _clinicAddressRepository;
    private readonly IFileHandler _fileHandler;

    public UpdateClinicAddressProfilePictureCommandHandler(
        IClinicAddressRepository clinicAddressRepository,
        IFileHandler fileHandler)
    {
        _clinicAddressRepository = clinicAddressRepository;
        _fileHandler = fileHandler;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdateClinicAddressProfilePictureCommand command, CancellationToken cancellationToken)
    {
        var clinicAddress =  (await _clinicAddressRepository.GetByIdAsync(command.ClinicAddressId));
        if (clinicAddress == null)
            return Errors.ClinicAddress.NotFound;
        
        if (clinicAddress.OwnerId != command.DoctorId)
            return Errors.User.YouCanNotDoThis;
            
        var result = SaveFile.SavePicture(command.Base64Picture, _fileHandler);
        if (result.IsError)
            return result.Errors;
        
        clinicAddress.ProfilPictureUrl = result.Value;

        await _clinicAddressRepository.Edit(clinicAddress);

        if (await _clinicAddressRepository.SaveAsync() == 0)
            return Errors.ClinicAddress.UpdateFailed;

        return new CommandResponse(
            true,
            "ClinicAddress profile picture updated successfully.",
            $"clinics/clinic-id/{clinicAddress.ClinicId}/adresses/address-id/{clinicAddress.Id}");

    }
}