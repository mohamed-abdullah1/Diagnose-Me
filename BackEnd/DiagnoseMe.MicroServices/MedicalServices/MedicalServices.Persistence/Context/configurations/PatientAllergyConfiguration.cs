using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.configurations;

public class PatientAllergyConfiguration : BaseConfiguration<PatientAllergy>
{
    public override void Configure(EntityTypeBuilder<PatientAllergy> builder)
    {
        builder.ToTable("PatientAllergies");
        builder.HasKey(pa => new {pa.PatientId, pa.AllergyId});
        builder.Property(pa => pa.PatientId).IsRequired().HasMaxLength(100);
        builder.Property(pa => pa.AllergyId).IsRequired().HasMaxLength(100);
    }
}