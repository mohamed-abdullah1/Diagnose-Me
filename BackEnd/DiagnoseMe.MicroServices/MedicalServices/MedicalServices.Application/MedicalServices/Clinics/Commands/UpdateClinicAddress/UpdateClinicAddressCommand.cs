using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicAddress;

public record UpdateClinicAddressCommand(
    string ClinicAddressId,
    string Name,
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode,
    string OpenTime,
    string CloseTime,
    string DoctorId
) : IRequest<ErrorOr<CommandResponse>>;
