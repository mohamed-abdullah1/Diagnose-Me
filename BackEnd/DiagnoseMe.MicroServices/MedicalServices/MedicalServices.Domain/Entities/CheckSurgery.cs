namespace MedicalServices.Domain.Entities;

public class CheckSurgery : BaseEntity
{
    public string CheckId { get; set; } = string.Empty;
    public virtual Check Check { get; set; } = new Check();
    public string SurgeryId { get; set; } = string.Empty;
    public virtual Surgery Surgery { get; set; } = new Surgery();
}