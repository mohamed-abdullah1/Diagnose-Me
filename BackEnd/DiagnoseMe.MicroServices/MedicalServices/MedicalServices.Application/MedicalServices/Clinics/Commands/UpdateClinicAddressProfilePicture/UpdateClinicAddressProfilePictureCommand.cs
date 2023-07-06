using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicAddressProfilePicture;


public record UpdateClinicAddressProfilePictureCommand(
    string ClinicAddressId,
    string Base64Picture,
    string DoctorId
) : IRequest<ErrorOr<CommandResponse>>;