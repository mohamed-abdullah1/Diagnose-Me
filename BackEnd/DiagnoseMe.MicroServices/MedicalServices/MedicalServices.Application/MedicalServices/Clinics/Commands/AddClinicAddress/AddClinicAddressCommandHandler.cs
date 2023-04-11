using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.Common.Interfaces.Services;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Application.MedicalServices.Helpers;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.AddClinicAddress;

public class AddClinicAddressCommandHandler : IRequestHandler<AddClinicAddressCommand, ErrorOr<CommandResponse>>
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IClinicAddressRepository _clinicAddressRepository;
    private readonly IFileHandler _fileHandler;
    public AddClinicAddressCommandHandler(
        IClinicRepository clinicRepository,
        IClinicAddressRepository addressRepository,
        IFileHandler fileHandler)
    {
        _clinicRepository = clinicRepository;
        _clinicAddressRepository = addressRepository;
        _fileHandler = fileHandler;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddClinicAddressCommand command, CancellationToken cancellationToken)
    {
        var clinic =  (await _clinicRepository.GetByIdAsync(command.ClinicId));
        if (clinic == null)
            return Errors.Clinic.NotFound;
        var address = new ClinicAddress{
            Id = Guid.NewGuid().ToString(),
            Name = command.Name,
            Street = command.Street,
            City = command.City,
            State = command.State,
            Country = command.Country,
            ZipCode = command.ZipCode,
            OpenTime = TimeOnly.ParseExact(command.OpenTime, "HH:mm"),
            CloseTime = TimeOnly.ParseExact(command.CloseTime, "HH:mm"),
            ClinicId = clinic.Id,
            CreatedOn = DateTime.Now,
            OwnerId = command.OwnerId};
        var result = SaveFile.SavePicture(command.Base64Picture, _fileHandler);
        if (result.IsError)
            return result.Errors;
        address.ProfilPictureUrl = result.Value;
        await _clinicAddressRepository.AddAsync(address);
        if (await _clinicAddressRepository.SaveAsync() == 0)
            return Errors.Clinic.AddFailed;
        return new CommandResponse(
            true,
            "Clinic address added successfully.",
            $"clinics/{clinic.Id}/addresses/address-id/{address.Id}");
        
    }
}