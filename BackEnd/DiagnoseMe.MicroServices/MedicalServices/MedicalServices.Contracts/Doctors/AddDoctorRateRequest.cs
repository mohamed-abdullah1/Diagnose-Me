namespace MedicalServices.Contracts.Doctors;

public record AddDoctorRateRequest(
    string DoctorId,
    int Rate,
    string? Comment);