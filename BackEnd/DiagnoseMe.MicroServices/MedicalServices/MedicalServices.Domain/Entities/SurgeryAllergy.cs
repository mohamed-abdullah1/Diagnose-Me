namespace MedicalServices.Domain.Entities;

public class SurgeryAllergy : BaseEntity
{
    public string SurgeryId { get; set; } = string.Empty;
    public Surgery Surgery { get; set; } = new Surgery();
    public string AllergyId { get; set; } = string.Empty;
    public Allergy Allergy { get; set; } = new Allergy();
}