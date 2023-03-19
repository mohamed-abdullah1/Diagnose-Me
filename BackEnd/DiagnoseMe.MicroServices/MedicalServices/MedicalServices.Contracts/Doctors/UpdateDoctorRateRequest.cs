namespace MedicalServices.Contracts.Doctors;

public record UpdateDoctorRateRequest(
    string DoctorId,
    int Rate,
    string? Comment);