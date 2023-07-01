using MedicalServices.Application.MedicalServices.Clinics.Common;
using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Common;

public record DoctorResponse(
    UserResponse User, 
    string Title,
    string Bio,
    string License,
    bool IsLicenseVerified,
    string ClinicId,
    string ClinicSpecialization,
    float AverageRate,
    int YearsOfExperience,
    int NumberOfPatients,
    List<ClinicAddressResponse> ClinicAddresses,
    List<DoctorRateResponse> DoctorRates);