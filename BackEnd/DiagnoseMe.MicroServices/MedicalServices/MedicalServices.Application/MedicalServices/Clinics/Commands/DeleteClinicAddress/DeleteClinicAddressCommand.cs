using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.DeleteClinicAddress;

public record DeleteClinicAddressCommand(
    string ClinicAddressId,
    string DoctorId) : IRequest<ErrorOr<CommandResponse>>;
