using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Doctors.Common;

public record DoctorRateResponse(
    string UserId,
    string DoctorId,
    int Rate,
    string? Comment,
    UserResponse User
);