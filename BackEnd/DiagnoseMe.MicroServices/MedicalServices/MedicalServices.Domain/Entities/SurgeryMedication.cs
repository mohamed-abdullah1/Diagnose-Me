namespace MedicalServices.Domain.Entities;


public class SurgeryMedication : BaseEntity
{
    public string SurgeryId { get; set; } = string.Empty;
    public Surgery Surgery { get; set; } = new Surgery();
    public string MedicationId { get; set; } = string.Empty;
    public Medication Medication { get; set; } = new Medication();
}