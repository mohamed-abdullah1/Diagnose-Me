namespace MedicalServices.Domain.Entities;

public class CheckAllergy : BaseEntity
{
    public string CheckId { get; set; } = string.Empty;
    public virtual Check Check { get; set; } = new Check();
    public string AllergyId { get; set; } = string.Empty;
    public virtual Allergy Allergy { get; set; } = new Allergy();
}
