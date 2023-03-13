using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.Common.Interfaces.Services;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Application.MedicalServcies.Helpers;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.UpdateClinicAddressProfilePicture;


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

        try{
            await _clinicAddressRepository.Edit(clinicAddress);
            await _clinicAddressRepository.Save();
            return new CommandResponse(
                true,
                "ClinicAddress profile picture updated successfully.",
                $"clinics/clinic-id/{clinicAddress.ClinicId}/adresses/address-id/{clinicAddress.Id}");
        }
        catch (Exception)
        {
            return Errors.ClinicAddress.UpdateFailed;
        }
    }
}