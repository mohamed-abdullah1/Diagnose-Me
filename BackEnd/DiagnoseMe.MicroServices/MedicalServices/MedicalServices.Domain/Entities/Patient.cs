namespace MedicalServices.Domain.Entities;

public class Patient : BaseEntity{
    public float Height {get; set;}
    public float Weight {get; set;}
    public virtual User User { get; set; } = null!;

    public virtual ICollection<PatientDoctor> PatientDoctors {get; set;} = new HashSet<PatientDoctor>();
    public virtual ICollection<DoctorRate> DoctorRates {get; set;} = new HashSet<DoctorRate>();
    public virtual ICollection<MedicalRecord> MedicalRecords {get; set;} = new HashSet<MedicalRecord>();
}