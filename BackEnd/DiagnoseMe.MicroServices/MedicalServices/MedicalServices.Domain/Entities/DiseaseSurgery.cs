namespace MedicalServices.Domain.Entities;

public class DiseaseSurgery : BaseEntity
{
    public string DiseaseId { get; set; } = string.Empty;
    public Disease Disease { get; set; } = new Disease();
    public string SurgeryId { get; set; } = string.Empty;
    public Surgery Surgery { get; set; } = new Surgery();
}