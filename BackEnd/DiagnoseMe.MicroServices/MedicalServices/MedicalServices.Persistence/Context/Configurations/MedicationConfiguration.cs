using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Dosage).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Frequency).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Notes).IsRequired().HasMaxLength(50);
        builder.HasMany(m => m.Allergies).
            WithMany(a => a.Medications).
            UsingEntity<MedicationAllergy>(
                ma => ma.HasOne(a => a.Allergy).
                    WithMany().
                    HasForeignKey(a => a.AllergyId)
                    .OnDelete(DeleteBehavior.Cascade),
                ma => ma.HasOne(m => m.Medication).
                    WithMany().
                    HasForeignKey(m => m.MedicationId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}