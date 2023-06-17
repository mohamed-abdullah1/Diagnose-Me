using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;


public class SurgeryConfiguration : BaseConfiguration<Surgery>
{
    public override void Configure(EntityTypeBuilder<Surgery> builder)
    {
        builder.ToTable("Surgeries");
        base.Configure(builder);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Type).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Notes).IsRequired().HasMaxLength(1000);
        builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);   
        builder.HasMany(s => s.Medications).
            WithMany(m => m.Surgeries).
            UsingEntity<SurgeryMedication>(
                sm => sm.HasOne(m => m.Medication).
                    WithMany().
                    HasForeignKey(m => m.MedicationId)
                    .OnDelete(DeleteBehavior.Cascade),
                sm => sm.HasOne(s => s.Surgery).
                    WithMany().
                    HasForeignKey(s => s.SurgeryId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(s => s.Allergies).
            WithMany(a => a.Surgeries).
            UsingEntity<SurgeryAllergy>(
                sa => sa.HasOne(a => a.Allergy).
                    WithMany().
                    HasForeignKey(a => a.AllergyId)
                    .OnDelete(DeleteBehavior.Cascade),
                sa => sa.HasOne(s => s.Surgery).
                    WithMany().
                    HasForeignKey(s => s.SurgeryId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}