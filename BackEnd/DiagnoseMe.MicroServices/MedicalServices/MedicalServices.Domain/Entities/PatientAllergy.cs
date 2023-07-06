namespace MedicalServices.Domain.Entities;

public class PatientAllergy : BaseEntity
{
    public string PatientId { get; set; } = string.Empty;
    public Patient Patient { get; set; } = new Patient();
    public string AllergyId { get; set; } = string.Empty;
    public Allergy Allergy { get; set; }    = new Allergy();
}