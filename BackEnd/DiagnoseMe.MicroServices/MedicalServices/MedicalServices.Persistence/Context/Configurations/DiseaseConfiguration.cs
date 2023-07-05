using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;


public class DiseaseConfiguration : BaseConfiguration<Disease>
{
    public override void Configure(EntityTypeBuilder<Disease> builder)
    {
        builder.ToTable("Diseases");
        base.Configure(builder);
        builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
        builder.Property(d => d.Description).IsRequired().HasMaxLength(100);
        builder.HasMany(d => d.Medications).
            WithMany(m => m.Diseases).
            UsingEntity<DiseaseMedication>(
                dm => dm.HasOne(m => m.Medication).
                    WithMany().
                    HasForeignKey(m => m.MedicationId)
                    .OnDelete(DeleteBehavior.Cascade),
                dm => dm.HasOne(d => d.Disease).
                    WithMany().
                    HasForeignKey(d => d.DiseaseId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(d => d.Allergies).
            WithMany(a => a.Diseases).
            UsingEntity<DiseaseAllergy>(
                da => da.HasOne(a => a.Allergy).
                    WithMany().
                    HasForeignKey(a => a.AllergyId)
                    .OnDelete(DeleteBehavior.Cascade),
                da => da.HasOne(d => d.Disease).
                    WithMany().
                    HasForeignKey(d => d.DiseaseId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(d => d.Surgeries).
            WithMany(s => s.Diseases).
            UsingEntity<DiseaseSurgery>(
                ds => ds.HasOne(s => s.Surgery).
                    WithMany().
                    HasForeignKey(s => s.SurgeryId)
                    .OnDelete(DeleteBehavior.Cascade),
                ds => ds.HasOne(d => d.Disease).
                    WithMany().
                    HasForeignKey(d => d.DiseaseId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}