namespace MedicalServices.Persistence.Context.Configrations;

using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MedicalRecordConfiguration : BaseConfiguration<MedicalRecord>
{
    public override void Configure(EntityTypeBuilder<MedicalRecord> builder)
    {
        builder.ToTable("MedicalRecords");
        base.Configure(builder);
        builder.Property(m => m.PatientId).IsRequired();
        builder.Property(m => m.DoctorId).IsRequired();
        builder.Property(m => m.Illness).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Diagnoses).IsRequired().HasMaxLength(50);
        builder.HasOne(m => m.Patient).WithMany(p => p.MedicalRecords).HasForeignKey(m => m.PatientId);
        builder.HasOne(m => m.Doctor).WithMany(d => d.MedicalRecords).HasForeignKey(m => m.DoctorId);
    }
}