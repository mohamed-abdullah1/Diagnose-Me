namespace MedicalServices.Persistence.Context.configurations;

using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PatientSurgeryConfiguration : BaseConfiguration<PatientSurgery>
{
    public override void Configure(EntityTypeBuilder<PatientSurgery> builder)
    {
        builder.ToTable("PatientSurgeries");
        builder.HasKey(ps => new {ps.PatientId, ps.SurgeryId});
        builder.Property(ps => ps.PatientId).IsRequired().HasMaxLength(100);
        builder.Property(ps => ps.SurgeryId).IsRequired().HasMaxLength(100);
        
    }
}