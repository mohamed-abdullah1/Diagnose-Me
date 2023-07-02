namespace MedicalServices.Domain.Entities;

public class DoctorClinicAddress : BaseEntity
{
    public string DoctorId { get; set; } = string.Empty;
    public virtual Doctor Doctor { get; set; } = null!;
    public string ClinicAddressId { get; set; } = string.Empty;
    public virtual ClinicAddress ClinicAddress { get; set; } = null!;
}