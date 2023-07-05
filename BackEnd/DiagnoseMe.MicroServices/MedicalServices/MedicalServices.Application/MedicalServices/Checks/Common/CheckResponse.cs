using MedicalServices.Application.MedicalServices.Doctors.Common;
using MedicalServices.Application.MedicalServices.Patients.Common;

namespace MedicalServices.Application.MedicalServices.Checks.Common;

public record CheckResponse(
    string Id,
    string Name,
    string Type,
    string Data,
    string Report,
    DoctorResponse? Doctor,
    PatientResponse Patient,
    List<MedicationResponse> Medications,
    List<DiseaseResponse> Diseases,
    List<AllergyResponse> Allergies,
    List<string> CheckFiles,
    List<SurgeryResponse> Surgeries
);