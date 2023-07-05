namespace MedicalServices.Domain.Entities;

public class PatientDisease : BaseEntity
{
    public string PatientId { get; set; } = string.Empty;
    public Patient Patient { get; set; } = new Patient();
    public string DiseaseId { get; set; } = string.Empty;
    public Disease Disease { get; set; } = new Disease();
}