using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.UpdateDoctor;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IDoctorRepository _doctorRepository;

    public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByIdAsync(command.DoctorId);
        if (doctor == null)
            return Errors.Doctor.NotFound;

        doctor.Bio = command.Bio;
        doctor.Title = command.Title;
        await _doctorRepository.Edit(doctor);
        if (await _doctorRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Doctor.UpdateFailed;
        return new CommandResponse(
            Success: true,
            Message: "Doctor updated successfully.",
            Path: $"Doctors/{command.DoctorId}"
        );
    }
}