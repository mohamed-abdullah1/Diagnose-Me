using System.Security;

namespace MedicalServices.Domain.Entities;

public class Check : BaseEntity{

    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public string Report { get; set; } = string.Empty;
    public string? DoctorId { get; set; } = string.Empty;
    public virtual Doctor? Doctor { get; set; } = new Doctor();
    public string PatientId { get; set; } = string.Empty;
    public virtual Patient Patient { get; set; } = new Patient();
    public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
    public virtual ICollection<Disease> Diseases { get; set; } = new List<Disease>();
    public virtual ICollection<Allergy> Allergies { get; set; } = new List<Allergy>();
    public virtual ICollection<CheckFile> CheckFiles { get; set; } = new List<CheckFile>();
    public virtual ICollection<Surgery> Surgeries { get; set; } = new List<Surgery>();

}