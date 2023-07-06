namespace MedicalServices.Domain.Entities;

public class DoctorSurgery : BaseEntity
{
    public string DoctorId { get; set; } = string.Empty;
    public Doctor Doctor { get; set; } = new Doctor();
    public string SurgeryId { get; set; } = string.Empty;
    public Surgery Surgery { get; set; } = new Surgery();
}