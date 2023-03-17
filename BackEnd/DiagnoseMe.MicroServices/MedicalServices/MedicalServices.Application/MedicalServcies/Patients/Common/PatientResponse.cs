namespace MedicalServices.Application.MedicalServcies.Patients.Common;

public record PatientResponse(
    string Id,
    string Name,
    string FullName,
    string ProfilePictureUrl, 
    string Hight,
    string Weight,
    List<string>? Allergies,
    List<string>? Diseases,
    List<string>? Medications,
    List<string>? Surgeries,
    List<CheckResponse>? Checks);