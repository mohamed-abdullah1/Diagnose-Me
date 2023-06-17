using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;


public class SurgeryAllergyConfiguration : BaseConfiguration<SurgeryAllergy>
{
    public override void Configure(EntityTypeBuilder<SurgeryAllergy> builder)
    {
        builder.ToTable("SurgeryAllergies");
        builder.HasKey(sa => new {sa.SurgeryId, sa.AllergyId});
        builder.Property(sa => sa.SurgeryId).IsRequired().HasMaxLength(100);
        builder.Property(sa => sa.AllergyId).IsRequired().HasMaxLength(100);
    }
}