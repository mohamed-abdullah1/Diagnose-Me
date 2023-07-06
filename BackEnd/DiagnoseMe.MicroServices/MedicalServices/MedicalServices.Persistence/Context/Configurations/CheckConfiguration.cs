using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class CheckConfiguration : BaseConfiguration<Check>
{
    public override void Configure(EntityTypeBuilder<Check> builder)
    {
        builder.ToTable("Checks");
        base.Configure(builder);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Type).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Data).IsRequired().HasMaxLength(500);
        builder.Property(c => c.Report).IsRequired().HasMaxLength(500);
        builder.Property(c => c.PatientId).IsRequired().HasMaxLength(50);
        builder.Property(c => c.DoctorId).IsRequired().HasMaxLength(50);
        builder.HasOne(c => c.Patient).WithMany(p => p.Checks).HasForeignKey(c => c.PatientId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(c => c.Doctor).WithMany(d => d.Checks).HasForeignKey(c => c.DoctorId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Medications).
            WithMany(m => m.Checks).
            UsingEntity<CheckMedication>(
                cm => cm.HasOne(m => m.Medication).
                    WithMany().
                    HasForeignKey(m => m.MedicationId)
                    .OnDelete(DeleteBehavior.Cascade),
                cm => cm.HasOne(c => c.Check).
                    WithMany().
                    HasForeignKey(c => c.CheckId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(c => c.Diseases).
            WithMany(d => d.Checks).
            UsingEntity<CheckDisease>(
                cd => cd.HasOne(d => d.Disease).
                    WithMany().
                    HasForeignKey(d => d.DiseaseId)
                    .OnDelete(DeleteBehavior.Cascade),
                cd => cd.HasOne(c => c.Check).
                    WithMany().
                    HasForeignKey(c => c.CheckId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(c => c.Allergies).
            WithMany(a => a.Checks).
            UsingEntity<CheckAllergy>(
                ca => ca.HasOne(a => a.Allergy).
                    WithMany().
                    HasForeignKey(a => a.AllergyId)
                    .OnDelete(DeleteBehavior.Cascade),
                ca => ca.HasOne(c => c.Check).
                    WithMany().
                    HasForeignKey(c => c.CheckId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(c => c.Surgeries).
            WithMany(s => s.Checks).
            UsingEntity<CheckSurgery>(
                cs => cs.HasOne(s => s.Surgery).
                    WithMany().
                    HasForeignKey(s => s.SurgeryId)
                    .OnDelete(DeleteBehavior.Cascade),
                cs => cs.HasOne(c => c.Check).
                    WithMany().
                    HasForeignKey(c => c.CheckId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}