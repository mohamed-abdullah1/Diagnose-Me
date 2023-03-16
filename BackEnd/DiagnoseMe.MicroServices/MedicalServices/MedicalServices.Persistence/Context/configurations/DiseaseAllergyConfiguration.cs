using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.configurations;

public class DiseaseAllergyConfiguration : BaseConfiguration<DiseaseAllergy>
{
    public override void Configure(EntityTypeBuilder<DiseaseAllergy> builder)
    {
        builder.ToTable("DiseaseAllergies");
        builder.HasKey(da => new {da.DiseaseId, da.AllergyId});
        builder.Property(da => da.DiseaseId).IsRequired().HasMaxLength(100);
        builder.Property(da => da.AllergyId).IsRequired().HasMaxLength(100);
    }
}