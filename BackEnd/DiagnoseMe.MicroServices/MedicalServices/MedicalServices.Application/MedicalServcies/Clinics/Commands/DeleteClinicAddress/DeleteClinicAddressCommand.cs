using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.DeleteClinicAddress;

public record DeleteClinicAddressCommand(
    string ClinicAddressId,
    string DoctorId) : IRequest<ErrorOr<CommandResponse>>;
