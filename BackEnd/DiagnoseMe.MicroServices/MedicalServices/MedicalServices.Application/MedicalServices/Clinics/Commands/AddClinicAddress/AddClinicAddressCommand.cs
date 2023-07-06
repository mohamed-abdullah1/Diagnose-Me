using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.AddClinicAddress;


public record AddClinicAddressCommand(
    string OwnerId,
    string ClinicId,
    string Name,
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode,
    string OpenTime,
    string CloseTime,
    string Latitude,
    string Longitude,
    string Base64Picture) : IRequest<ErrorOr<CommandResponse>>;