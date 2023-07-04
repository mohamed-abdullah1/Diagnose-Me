namespace MedicalServices.Domain.Entities;


public class Doctor : BaseEntity{
    public string? Title { get; set; } = string.Empty;
    public string? Bio { get; set; } = string.Empty;
    public string? License { get; set; } = string.Empty;
    public bool IsLicenseVerified {get; set;}
    public string? ClinicId { get; set; }
    public float AverageRate {get; set;}
    public int PricePerSession {get; set;}
    public int YearsOfExperience {get; set;}
    public virtual Clinic? Clinic { get; set; }
    public virtual User? User { get; set; }
    public virtual ICollection<Patient> Patients {get; set;} = new HashSet<Patient>();
    public virtual ICollection<DoctorRate> DoctorRates {get; set;} = new HashSet<DoctorRate>();
    public virtual ICollection<Medication> Medications {get; set;} = new HashSet<Medication>();
    public virtual ICollection<Surgery> Surgeries {get; set;} = new HashSet<Surgery>();
    public virtual ICollection<ClinicAddress> ClinicAddresses {get; set;} = new HashSet<ClinicAddress>();
    public virtual ICollection<ClinicAddress> OwnedClinicAddresses {get; set;} = new HashSet<ClinicAddress>();
    public virtual ICollection<Check> Checks {get; set;} = new HashSet<Check>();
}