namespace MedicalServices.Domain.Entities;

public class ClinicAddress : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string? ClinicId { get; set; }
    public string ProfilPictureUrl { get; set; } = string.Empty;
    public virtual Clinic? Clinic { get; set; }
    public virtual ICollection<DoctorClinicAddress> DoctorClinicAddresses {get; set;} = new HashSet<DoctorClinicAddress>();    
}