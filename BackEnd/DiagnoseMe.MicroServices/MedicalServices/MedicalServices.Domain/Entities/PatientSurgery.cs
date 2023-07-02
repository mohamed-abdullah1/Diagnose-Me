namespace MedicalServices.Domain.Entities;

public class PatientSurgery : BaseEntity
{
    public string PatientId { get; set; } = string.Empty;
    public Patient Patient { get; set; } = new Patient();
    public string SurgeryId { get; set; } = string.Empty;
    public Surgery Surgery { get; set; } = new Surgery();
}