namespace MedicalServices.Domain.Entities;

public class DiseaseMedication : BaseEntity
{
    public string DiseaseId { get; set; } = string.Empty;
    public Disease Disease { get; set; } = new Disease();
    public string MedicationId { get; set; } = string.Empty;
    public Medication Medication { get; set; } = new Medication();
}