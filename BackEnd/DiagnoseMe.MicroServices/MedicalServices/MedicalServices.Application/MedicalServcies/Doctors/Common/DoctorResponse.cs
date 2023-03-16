namespace MedicalServices.Application.MedicalServcies.Doctors.Common;

public record DoctorResponse(
    string Id,
    string Name,
    string FullName,
    string ProfilePictureUrl, 
    string Title,
    string Bio,
    string License,
    bool IsLicenseVerified,
    string ClinicId);