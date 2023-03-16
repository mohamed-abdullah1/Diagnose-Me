namespace MedicalServices.Domain.Entities;


public class Disease : BaseEntity
{
    public string Name {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public ICollection<Allergy> Allergies {get; set;} = new List<Allergy>();
    public ICollection<Medication> Medications {get; set;} = new List<Medication>();
    public ICollection<Surgery> Surgeries {get; set;} = new List<Surgery>();
    public ICollection<Patient> Patients {get; set;} = new List<Patient>();
}