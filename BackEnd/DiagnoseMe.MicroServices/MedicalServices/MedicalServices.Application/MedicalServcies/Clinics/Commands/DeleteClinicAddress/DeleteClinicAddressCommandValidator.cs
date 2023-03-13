using FluentValidation;

namespace MedicalServices.Application.MedicalServcies.Clinics.Commands.DeleteClinicAddress;


public class DeleteClinicAddressCommandValidator : AbstractValidator<DeleteClinicAddressCommand>
{
    public DeleteClinicAddressCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("DoctorId is required");
        RuleFor(x => x.ClinicAddressId)
            .NotEmpty()
            .WithMessage("ClinicAddressId is required");
    }
}