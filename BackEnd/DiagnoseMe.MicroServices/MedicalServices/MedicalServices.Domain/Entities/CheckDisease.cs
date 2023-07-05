namespace MedicalServices.Domain.Entities;

public class CheckDisease : BaseEntity
{
    public string CheckId { get; set; } = string.Empty;
    public virtual Check Check { get; set; } = new Check();
    public string DiseaseId { get; set; } = string.Empty;
    public virtual Disease Disease { get; set; } = new Disease();
}
