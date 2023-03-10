using FluentValidation;

namespace MedicalServices.Application.Clinics.Queries.GetClinicAddresses;

public class GetClinicAddressesQueryValidator : AbstractValidator<GetClinicAddressesQuery>
{
    public GetClinicAddressesQueryValidator()
    {
        RuleFor(x => x.ClinicId).
        NotEmpty().
        WithMessage("Clinic id is required");
        RuleFor(x => x.PageNumber).
        NotEmpty().
        WithMessage("Page number is required").
        GreaterThanOrEqualTo(1).
        WithMessage("Page number must be positive number");
    }
}