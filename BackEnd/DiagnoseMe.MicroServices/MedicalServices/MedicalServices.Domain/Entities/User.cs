namespace MedicalServices.Domain.Entities;

public class User : BaseEntity
{
    public string Name {get; set;} = string.Empty;
    public string FullName {get; set;} = string.Empty;
    public string ProfilePictureUrl {get; set;} = string.Empty;
    public bool IsDoctor {get; set;}
    public virtual Doctor? Doctor {get; set;}
    public virtual Patient? Patient {get; set;}
    public virtual ICollection<DoctorRate> DoctorRates {get; set;} = new HashSet<DoctorRate>();
}