using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;


public class MedicationAllergyConfiguration : BaseConfiguration<MedicationAllergy>
{
    public override void Configure(EntityTypeBuilder<MedicationAllergy> builder)
    {
        builder.ToTable("MedicationAllergies");
        builder.HasKey(ma => new {ma.MedicationId, ma.AllergyId});
        builder.Property(ma => ma.MedicationId).IsRequired().HasMaxLength(100);
        builder.Property(ma => ma.AllergyId).IsRequired().HasMaxLength(100);
    }
}