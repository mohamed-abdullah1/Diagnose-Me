namespace MedicalServices.Domain.Entities;
public class CheckMedication : BaseEntity
{
    public string CheckId { get; set; } = string.Empty;
    public virtual Check Check { get; set; } = new Check();
    public string MedicationId { get; set; } = string.Empty;
    public virtual Medication Medication { get; set; } = new Medication();
}
