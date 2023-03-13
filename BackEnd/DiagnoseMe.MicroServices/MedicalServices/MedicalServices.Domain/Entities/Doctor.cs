namespace MedicalServices.Domain.Entities;


public class Doctor : BaseEntity{
    public string Title { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string License { get; set; } = string.Empty;
    public bool IsLicenseVerified {get; set;}
    public string? ClinicId { get; set; }
    public virtual Clinic? Clinic { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual ICollection<PatientDoctor> PatientDoctors {get; set;} = new HashSet<PatientDoctor>();
    public virtual ICollection<DoctorRate> DoctorRates {get; set;} = new HashSet<DoctorRate>();
    public virtual ICollection<MedicalRecord> MedicalRecords {get; set;} = new HashSet<MedicalRecord>();
    public virtual ICollection<DoctorClinicAddress> DoctorClinicAddresses {get; set;} = new HashSet<DoctorClinicAddress>();
    public virtual ICollection<ClinicAddress> OwnedClinicAddresses {get; set;} = new HashSet<ClinicAddress>();
}