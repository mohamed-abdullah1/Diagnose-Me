using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class CheckAllergyConfiguratiom : BaseConfiguration<CheckAllergy>
{
    public override void Configure(EntityTypeBuilder<CheckAllergy> builder)
    {
        builder.ToTable("CheckAllergies");
        builder.HasKey(c => new { c.CheckId, c.AllergyId });
        builder.Property(c => c.CheckId).IsRequired().HasMaxLength(50);
        builder.Property(c => c.AllergyId).IsRequired().HasMaxLength(50);
    }
}