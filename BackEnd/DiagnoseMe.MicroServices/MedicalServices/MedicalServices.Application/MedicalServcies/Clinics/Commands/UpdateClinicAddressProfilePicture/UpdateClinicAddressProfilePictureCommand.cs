using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.UpdateClinicAddressProfilePicture;


public record UpdateClinicAddressProfilePictureCommand(
    string ClinicAddressId,
    string Base64Picture,
    string DoctorId
) : IRequest<ErrorOr<CommandResponse>>;