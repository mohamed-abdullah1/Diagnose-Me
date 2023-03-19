namespace MedicalServices.Domain.Entities;

public class DoctorRate : BaseEntity{

    public int Rate {get; set;}
    public string? Comment {get; set;}
    public string? UserId {get; set;}
    public string? DoctorId {get; set;}
    public virtual Doctor Doctor {get; set;} = new Doctor();
    public virtual User User {get; set;} = new User();
}