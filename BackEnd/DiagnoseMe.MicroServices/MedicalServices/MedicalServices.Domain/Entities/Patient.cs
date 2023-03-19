namespace MedicalServices.Domain.Entities;

public class Patient : BaseEntity{
    public float Height {get; set;}
    public float Weight {get; set;}
    public virtual User User { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors {get; set;} = new HashSet<Doctor>();
    public virtual ICollection<Allergy> Allergies {get; set;} = new HashSet<Allergy>();
    public virtual ICollection<Medication> Medications {get; set;} = new HashSet<Medication>();
    public virtual ICollection<Surgery> Surgeries {get; set;} = new HashSet<Surgery>();
    public virtual ICollection<Disease> Diseases {get; set;} = new HashSet<Disease>();

}