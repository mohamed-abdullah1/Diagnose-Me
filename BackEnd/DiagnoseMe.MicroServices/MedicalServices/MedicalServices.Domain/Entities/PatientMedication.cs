namespace MedicalServices.Domain.Entities;


public class PatientMedication : BaseEntity
{
    public string PatientId { get; set; } = string.Empty;
    public Patient Patient { get; set; } = new Patient();
    public string MedicationId { get; set; } = string.Empty;
    public Medication Medication { get; set; } = new Medication();
}