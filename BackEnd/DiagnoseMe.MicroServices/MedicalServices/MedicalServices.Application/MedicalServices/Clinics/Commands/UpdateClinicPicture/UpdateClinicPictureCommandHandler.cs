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
        var result = FileConverter.ConvertToPng(command.Base64Picture);
        var rMQFileResponse = new RMQFileResponse(
            FilePath: StaticPaths.ClinicsImages,
            File: result.Value);
        
        if (result.IsError)
            return result.Errors;
        clinic.PictureUrl = Path.Combine(rMQFileResponse.FilePath, rMQFileResponse.File.FileName);

        await _clinicRepository.Edit(clinic);

        if (await _clinicRepository.SaveAsync() == 0)
            return Errors.Clinic.UpdateFailed;

        return new CommandResponse(
            true,
            "Clinic picture updated successfully.",
            $"clinics/{clinic.Id}");
    
    }
}
