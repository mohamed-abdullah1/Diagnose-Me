using MedicalServices.Application.MedicalServcies.Doctors.Common;

namespace MedicalServices.Application.MedicalServcies.Clinics.Common;

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