using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Helpers;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicAddressProfilePicture;


public class UpdateClinicAddressProfilePictureCommandHandler : IRequestHandler<UpdateClinicAddressProfilePictureCommand, ErrorOr<CommandResponse>>
{
    private readonly IClinicAddressRepository _clinicAddressRepository;
    private readonly IMessageQueueManager _messageQueueManager;
    public UpdateClinicAddressProfilePictureCommandHandler(
        IClinicAddressRepository clinicAddressRepository,
        IMessageQueueManager messageQueueManager)
    {
        _clinicAddressRepository = clinicAddressRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdateClinicAddressProfilePictureCommand command, CancellationToken cancellationToken)
    {
        var clinicAddress =  (await _clinicAddressRepository.GetByIdAsync(command.ClinicAddressId));
        if (clinicAddress == null)
            return Errors.ClinicAddress.NotFound;
        
        if (clinicAddress.OwnerId != command.DoctorId)
            return Errors.User.YouCanNotDoThis;
            
        var result = FileHelper.CheckImage(
            command.Base64Picture,
            StaticPaths.ClinicsImages
        );
        
        if (result.IsError)
            return result.Errors;
        
        clinicAddress.ProfilPictureUrl = result.Value.FilePath;

        await _clinicAddressRepository.Edit(clinicAddress);

        if (await _clinicAddressRepository.SaveAsync() == 0)
            return Errors.ClinicAddress.UpdateFailed;

        _messageQueueManager.PublishFile(new List<RMQFileResponse>{result.Value});
        return new CommandResponse(
            true,
            "ClinicAddress profile picture updated successfully.",
            $"clinics/clinic-id/{clinicAddress.ClinicId}/adresses/address-id/{clinicAddress.Id}");

    }
}