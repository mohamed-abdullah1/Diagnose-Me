using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.UpdatePricePerSession;

public record UpdatePricePerSessionCommand(
    string doctorId,
    int price) : IRequest<ErrorOr<CommandResponse>>;