namespace MedicalServices.Domain.Entities;


public class Medication : BaseEntity
{
    public string Name {get; set;} = string.Empty;
    public string Dosage {get; set;} = string.Empty;
    public string Frequency {get; set;} = string.Empty;
    public string Notes {get; set;} = string.Empty;

    public ICollection<Doctor> Doctors {get; set;} = new List<Doctor>();
    public ICollection<Surgery> Surgeries {get; set;} = new List<Surgery>();
    public ICollection<Patient> Patients {get; set;} = new List<Patient>();
    public ICollection<Allergy> Allergies {get; set;} = new List<Allergy>();
    public ICollection<Disease> Diseases {get; set;} = new List<Disease>();
    public ICollection<Check> Checks {get; set;} = new List<Check>();
}