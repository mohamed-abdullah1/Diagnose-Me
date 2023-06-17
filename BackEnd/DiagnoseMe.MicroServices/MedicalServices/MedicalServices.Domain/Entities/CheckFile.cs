namespace MedicalServices.Domain.Entities;

public class CheckFile : BaseEntity
{
    public string CheckId { get; set; } = string.Empty;
    public virtual Check Check { get; set; } = new Check();
    public string FileUrl { get; set; } = string.Empty;
}
