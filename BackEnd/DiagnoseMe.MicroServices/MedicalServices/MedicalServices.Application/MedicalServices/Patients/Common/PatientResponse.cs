using MedicalServices.Application.MedicalServices.Common;

namespace MedicalServices.Application.MedicalServices.Patients.Common;

public record PatientResponse(
    UserResponse User,
    string Hight,
    string Weight,
    List<string>? Allergies,
    List<string>? Diseases,
    List<string>? Medications,
    List<string>? Surgeries
    );