namespace MedicalServices.Domain.Entities;

public class Surgery : BaseEntity
{
    public string Name {get; set;} = string.Empty;
    public string Type {get; set;} = string.Empty;
    public string Notes {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public ICollection<Medication> Medications {get; set;} = new List<Medication>();
    public ICollection<Patient> Patients {get; set;} = new List<Patient>();
    public ICollection<Doctor> Doctors {get; set;} = new List<Doctor>();
    public ICollection<Disease> Diseases {get; set;} = new List<Disease>();
    public ICollection<Allergy> Allergies {get; set;} = new List<Allergy>();
    public ICollection<Check> Checks {get; set;} = new List<Check>();
}