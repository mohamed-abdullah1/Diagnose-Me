using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.UpdateClinicPicture;


public record UpdateClinicPictureCommand(
    string ClinicId,
    string Base64Picture): IRequest<ErrorOr<CommandResponse>>;