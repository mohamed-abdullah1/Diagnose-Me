namespace MedicalServices.Domain.Entities;


public class Allergy : BaseEntity
{
    public string Name {get; set;} = string.Empty;
    public string Type {get; set;} = string.Empty;
    public string Severity {get; set;} = string.Empty;
    public string Symptoms {get; set;} = string.Empty;
    public string Treatment {get; set;} = string.Empty;
    public string Notes {get; set;} = string.Empty;
    public virtual ICollection<Medication>  Medications {get; set;} = new List< Medication>();
    public virtual ICollection<Disease> Diseases {get; set;} = new List<Disease>();
    public virtual ICollection<Surgery> Surgeries {get; set;} = new List<Surgery>();
    public virtual ICollection<Patient> Patients {get; set;} = new List<Patient>();
    public virtual ICollection<Check> Checks {get; set;} = new List<Check>();
}