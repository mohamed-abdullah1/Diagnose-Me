using ErrorOr;
using MediatR;
using MedicalServices.Application.MedicalServcies.Clinics.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Queries.GetClinicAdresses;

public record GetClinicAddressesQuery(
    string ClinicId,
    int PageNumber) : IRequest<ErrorOr<List<ClinicAddressResponse>>>;
