using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Common;

public record DoctorResponse(
    UserResponse User, 
    string Title,
    string Bio,
    string License,
    bool IsLicenseVerified,
    string ClinicId,
    float AverageRate,
    List<DoctorRateResponse> DoctorRates);