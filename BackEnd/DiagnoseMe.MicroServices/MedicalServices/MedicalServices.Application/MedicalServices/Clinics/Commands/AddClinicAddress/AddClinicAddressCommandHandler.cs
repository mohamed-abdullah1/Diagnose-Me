using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Helpers;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.AddClinicAddress;

public class AddClinicAddressCommandHandler : IRequestHandler<AddClinicAddressCommand, ErrorOr<CommandResponse>>
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IClinicAddressRepository _clinicAddressRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMessageQueueManager _messageQueueManager;
    public AddClinicAddressCommandHandler(
        IClinicRepository clinicRepository,
        IClinicAddressRepository addressRepository,
        IDoctorRepository doctorRepository,
        IMessageQueueManager messageQueueManager)
        {
        _clinicRepository = clinicRepository;
        _clinicAddressRepository = addressRepository;
        _doctorRepository = doctorRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddClinicAddressCommand command, CancellationToken cancellationToken)
    {
        var clinic =  (await _clinicRepository.GetByIdAsync(command.ClinicId));
        if (clinic == null)
            return Errors.Clinic.NotFound;
        
        var owner = await _doctorRepository.GetByIdAsync(command.OwnerId);
        if (owner == null)
            return Errors.User.NotFound;

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
        address.Clinic = clinic;
        address.Owner = owner;
        var result = FileHelper.CheckImage(
            command.Base64Picture,
            StaticPaths.ClinicsImages
        );
        
        if (result.IsError)
            return result.Errors;
        address.ProfilPictureUrl = result.Value.FilePath;
        await _clinicAddressRepository.AddAsync(address);
        if (await _clinicAddressRepository.SaveAsync() == 0)
            return Errors.Clinic.AddFailed;
        
        _messageQueueManager.PublishFile(new List<RMQFileResponse>{result.Value});
        return new CommandResponse(
            true,
            "Clinic address added successfully.",
            $"clinics/{clinic.Id}/addresses/address-id/{address.Id}");
        
    }
}