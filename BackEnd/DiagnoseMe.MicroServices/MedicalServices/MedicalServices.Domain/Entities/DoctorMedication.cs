namespace MedicalServices.Domain.Entities;

public class DoctorMedication : BaseEntity
{
    public string DoctorId { get; set; } = string.Empty;
    public Doctor Doctor { get; set; } = new Doctor();
    public string MedicationId { get; set; } = string.Empty;
    public Medication Medication { get; set; } = new Medication();
}