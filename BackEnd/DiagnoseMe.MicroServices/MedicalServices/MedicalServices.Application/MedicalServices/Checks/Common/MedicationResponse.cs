namespace MedicalServices.Application.MedicalServices.Checks.Common;

public record MedicationResponse(
    string Id,
    string Name,
    string Dosage,
    string Frequency,
    string Notes
);