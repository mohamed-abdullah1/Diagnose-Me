namespace MedicalServices.Domain.Entities;

public class MedicationAllergy : BaseEntity
{
    public string MedicationId { get; set; } = string.Empty;
    public Medication Medication { get; set; } = new Medication();
    public string AllergyId { get; set; } = string.Empty;
    public Allergy Allergy { get; set; } = new Allergy();
}