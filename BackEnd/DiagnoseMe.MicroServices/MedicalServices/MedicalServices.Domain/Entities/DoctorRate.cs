namespace MedicalServices.Domain.Entities;

public class DoctorRate : BaseEntity{

    public int Rate {get; set;}
    public string? PatientId {get; set;}
    public string? DoctorId {get; set;}
    public virtual Doctor Doctor {get; set;} = new Doctor();
    public virtual Patient Patient {get; set;} = new Patient();
}