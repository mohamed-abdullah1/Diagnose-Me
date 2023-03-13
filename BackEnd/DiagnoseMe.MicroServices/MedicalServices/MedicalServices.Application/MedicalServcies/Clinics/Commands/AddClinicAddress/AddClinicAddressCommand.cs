using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.AddClinicAddress;


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
    string Base64Picture) : IRequest<ErrorOr<CommandResponse>>;