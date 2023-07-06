using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class DoctorConfiguration : BaseConfiguration<Doctor>
{
    public override void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");
        base.Configure(builder);
        builder.Property(d => d.Title);
        builder.Property(d => d.Bio);
        builder.Property(d => d.License);
        builder.Property(d => d.IsLicenseVerified);
        builder.Property(d => d.PricePerSession);
        builder.Property(d => d.ClinicId);
        builder.Property(d => d.AverageRate);
        builder.Property(d => d.YearsOfExperience);
        builder.HasOne(d => d.Clinic).WithMany(c => c.Doctors).HasForeignKey(d => d.ClinicId);
        builder.HasMany(d => d.Medications).
            WithMany(m => m.Doctors).
            UsingEntity<DoctorMedication>(
                dm => dm.HasOne(m => m.Medication).
                    WithMany().
                    HasForeignKey(m => m.MedicationId)
                    .OnDelete(DeleteBehavior.Cascade),
                dm => dm.HasOne(d => d.Doctor).
                    WithMany().
                    HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(d => d.Surgeries).
            WithMany(s => s.Doctors).
            UsingEntity<DoctorSurgery>(
                ds => ds.HasOne(s => s.Surgery).
                    WithMany().
                    HasForeignKey(s => s.SurgeryId)
                    .OnDelete(DeleteBehavior.Cascade),
                ds => ds.HasOne(d => d.Doctor).
                    WithMany().
                    HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}