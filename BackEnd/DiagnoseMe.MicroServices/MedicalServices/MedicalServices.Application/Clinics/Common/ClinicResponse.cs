namespace MedicalServices.Application.Clinics.Common;


public record ClinicResponse(
    string Id,
    string Specialization,
    string Description,
    string PictureUrl,
    int DoctorsCount,
    int ClinicAddressesCount);
