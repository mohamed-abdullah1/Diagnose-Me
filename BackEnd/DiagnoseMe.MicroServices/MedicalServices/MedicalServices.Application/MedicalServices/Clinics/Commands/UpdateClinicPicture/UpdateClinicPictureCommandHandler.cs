using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.Common.Interfaces.Services;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Helpers;
using MedicalServices.Domain.Common.Errors;


namespace MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicPicture;


public class UpdateClinicPictureCommandHandler : IRequestHandler<UpdateClinicPictureCommand, ErrorOr<CommandResponse>>
{
    private readonly IFileHandler _fileHandler;
    private readonly IClinicRepository _clinicRepository;
    public UpdateClinicPictureCommandHandler(
        IFileHandler fileHandler,
        IClinicRepository clinicRepository)
    {
        _fileHandler = fileHandler;
        _clinicRepository = clinicRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdateClinicPictureCommand command, CancellationToken cancellationToken)
    {
        var clinic =  (await _clinicRepository.GetByIdAsync(command.ClinicId));
        if (clinic == null)
            return Errors.Clinic.NotFound;
        var result = SaveFile.SavePicture(command.Base64Picture, _fileHandler);
        if (result.IsError)
            return result.Errors;
        clinic.PictureUrl = result.Value;

        await _clinicRepository.Edit(clinic);

        if (await _clinicRepository.SaveAsync() == 0)
            return Errors.Clinic.UpdateFailed;

        return new CommandResponse(
            true,
            "Clinic picture updated successfully.",
            $"clinics/{clinic.Id}");
    
    }
}
