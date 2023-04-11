using MedicalServices.Application.MedicalServices.Doctors.Common;

namespace MedicalServices.Application.MedicalServices.Clinics.Common;

public record ClinicAddressResponse(
    string Id,
    string Name,
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode,
    string OwnerId,
    string OpenTime,
    string CloseTime,
    DoctorResponse Owner,
    string ProfilPictureUrl);