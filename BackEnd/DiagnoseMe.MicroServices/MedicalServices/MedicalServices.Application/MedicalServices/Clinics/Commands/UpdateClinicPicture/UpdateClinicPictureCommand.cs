using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicPicture;


public record UpdateClinicPictureCommand(
    string ClinicId,
    string Base64Picture): IRequest<ErrorOr<CommandResponse>>;