using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.Common.Helpers;
using MedicalServices.Domain.Common;
using MedicalServices.Domain.Common.Errors;


namespace MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicPicture;


public class UpdateClinicPictureCommandHandler : IRequestHandler<UpdateClinicPictureCommand, ErrorOr<CommandResponse>>
{
    private readonly IMessageQueueManager   _messageQueueManager;
    private readonly IClinicRepository _clinicRepository;
    public UpdateClinicPictureCommandHandler(
        IClinicRepository clinicRepository,
        IMessageQueueManager messageQueueManager)
    {
        _clinicRepository = clinicRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdateClinicPictureCommand command, CancellationToken cancellationToken)
    {
        var clinic =  (await _clinicRepository.GetByIdAsync(command.ClinicId));
        if (clinic == null)
            return Errors.Clinic.NotFound;
        var result = FileHelper.CheckImage(
            command.Base64Picture,
            StaticPaths.ClinicsImages
        );
        
        if (result.IsError)
            return result.Errors;
        clinic.PictureUrl = result.Value.FilePath;

        await _clinicRepository.Edit(clinic);

        if (await _clinicRepository.SaveAsync() == 0)
            return Errors.Clinic.UpdateFailed;

        _messageQueueManager.PublishFile(new List<RMQFileResponse>{result.Value});
        return new CommandResponse(
            true,
            "Clinic picture updated successfully.",
            $"clinics/{clinic.Id}");
    
    }
}
