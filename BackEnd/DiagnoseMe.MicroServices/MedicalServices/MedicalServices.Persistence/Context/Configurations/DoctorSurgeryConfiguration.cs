using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class DoctorSurgeryConfiguration : BaseConfiguration<DoctorSurgery>
{
    public override void Configure(EntityTypeBuilder<DoctorSurgery> builder)
    {
        builder.ToTable("DoctorSurgeries");
        builder.HasKey(ds => new {ds.DoctorId, ds.SurgeryId});
        builder.Property(ds => ds.DoctorId).IsRequired().HasMaxLength(100);
        builder.Property(ds => ds.SurgeryId).IsRequired().HasMaxLength(100);
    }
}