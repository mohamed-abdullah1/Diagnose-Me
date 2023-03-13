using ErrorOr;
using FileTypeChecker.Extensions;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.Common.Interfaces.Services;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Application.MedicalServcies.Helpers;
using MedicalServices.Domain.Common.Errors;


namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.UpdateClinicPicture;


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
        try{
            await _clinicRepository.Edit(clinic);
            await _clinicRepository.Save();
            return new CommandResponse(
                true,
                "Clinic picture updated successfully.",
                $"clinics/{clinic.Id}");
        }
        catch (Exception)
        {
            return Errors.Clinic.UpdateFailed;
        }
    }
}
