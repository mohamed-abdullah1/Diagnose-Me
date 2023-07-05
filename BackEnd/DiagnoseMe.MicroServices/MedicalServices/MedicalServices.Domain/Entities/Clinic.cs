namespace MedicalServices.Domain.Entities;

public class Clinic : BaseEntity{

    public string Specialization { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    public virtual ICollection<Doctor> Doctors {get; set;} = new HashSet<Doctor>();
    public virtual ICollection<ClinicAddress> ClinicAddresses {get; set;} = new HashSet<ClinicAddress>();
}