using ErrorOr;
using FileTypeChecker.Extensions;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.Common.Interfaces.Services;
using MedicalServices.Application.MedicalServcies.Common;
using MedicalServices.Application.MedicalServcies.Helpers;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.AddClinic;


public class AddClinicCommandHandler : IRequestHandler<AddClinicCommand, ErrorOr<CommandResponse>>
{
    private readonly IFileHandler _fileHandler;
    private readonly IClinicRepository _clinicRepository;
    public AddClinicCommandHandler(
        IFileHandler fileHandler,
        IClinicRepository clinicRepository)
    {
        _fileHandler = fileHandler;
        _clinicRepository = clinicRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddClinicCommand command, CancellationToken cancellationToken)
    {
        var clinic =  (await _clinicRepository.
        Get(x => x.Specialization == command.Specialization)).
            ToList().
            FirstOrDefault();
        if (clinic != null)
            return Errors.Clinic.Exists;
        var result = SaveFile.SavePicture(command.Base64Picture, _fileHandler);
        
        if (result.IsError)
            return result.Errors;
            
        var pictureUrl = result.Value;
        clinic = new Clinic{
            Id = Guid.NewGuid().ToString(),
            Specialization = command.Specialization,
            Description = command.Description,
            PictureUrl = pictureUrl,
            CreatedOn = DateTime.Now
        };
        await _clinicRepository.AddAsync(clinic);
        if (await _clinicRepository.SaveAsync() == 0)
            return Errors.Clinic.AddFailed;

        return new CommandResponse(
            true,
            "Clinic added successfully.",
            $"clinics/{clinic.Id}");
    }
}