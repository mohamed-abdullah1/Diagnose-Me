using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.configurations;


public class DoctorClinicAddressConfiguration : BaseConfiguration<DoctorClinicAddress>
{
    public override void Configure(EntityTypeBuilder<DoctorClinicAddress> builder)
    {
        builder.ToTable("DoctorClinicAdresses");
        builder.HasKey(dca => new { dca.DoctorId, dca.ClinicAddressId });
        builder.Property(dca => dca.DoctorId).IsRequired().HasMaxLength(100);
        builder.Property(dca => dca.ClinicAddressId).IsRequired().HasMaxLength(100);
    }
}