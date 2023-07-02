using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Helpers;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;

using MedicalServices.Domain.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.AddClinic;


public class AddClinicCommandHandler : IRequestHandler<AddClinicCommand, ErrorOr<CommandResponse>>
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IMessageQueueManager _messageQueueManager;
    
    public AddClinicCommandHandler(
        IClinicRepository clinicRepository,
        IMessageQueueManager messageQueueManager)
    {
        _clinicRepository = clinicRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddClinicCommand command, CancellationToken cancellationToken)
    {
        var clinic =  (await _clinicRepository.
        Get(x => x.Specialization == command.Specialization)).
            ToList().
            FirstOrDefault();
        if (clinic != null)
            return Errors.Clinic.Exists;
        
        var result = FileConverter.ConvertToPng(command.Base64Picture);
        var rMQFileResponse = new RMQFileResponse(
            FilePath: StaticPaths.ClinicsImages,
            File: result.Value);
        
        if (result.IsError)
            return result.Errors;
            
        
        clinic = new Clinic{
            Id = Guid.NewGuid().ToString(),
            Specialization = command.Specialization,
            Description = command.Description,
            PictureUrl = Path.Combine(rMQFileResponse.FilePath, rMQFileResponse.File.FileName),
            CreatedOn = DateTime.Now
        };
        await _clinicRepository.AddAsync(clinic);
        if (await _clinicRepository.SaveAsync() == 0)
            return Errors.Clinic.AddFailed;

        _messageQueueManager.PublishFile(new List<RMQFileResponse>{rMQFileResponse});
        return new CommandResponse(
            true,
            "Clinic added successfully.",
            $"clinics/{clinic.Id}");
    }
}