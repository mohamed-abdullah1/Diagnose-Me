using ErrorOr;
using MediatR;
using MedicalServices.Application.Clinics.Common;

namespace MedicalServices.Application.Clinics.Queries.GetClinicAddresses;

public record GetClinicAddressesQuery(
    string ClinicId,
    int PageNumber
) : IRequest<ErrorOr<List<ClinicAddressResponse>>>;
