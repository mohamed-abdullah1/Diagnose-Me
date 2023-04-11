using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServices.Clinics.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Queries.GetClinicAdresses;

public record GetClinicAddressesQuery(
    string ClinicId,
    int PageNumber) : IRequest<ErrorOr<List<ClinicAddressResponse>>>;
