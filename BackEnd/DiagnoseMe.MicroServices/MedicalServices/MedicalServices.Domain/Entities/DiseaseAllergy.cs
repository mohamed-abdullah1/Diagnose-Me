namespace MedicalServices.Domain.Entities;


public class DiseaseAllergy : BaseEntity
{
    public string DiseaseId { get; set; } = string.Empty;
    public Disease Disease { get; set; } = new Disease();
    public string AllergyId { get; set; } = string.Empty;
    public Allergy Allergy { get; set; } = new Allergy();
}