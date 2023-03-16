using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.configurations;


public class AllergyConfiguration : BaseConfiguration<Allergy>
{
    public override void Configure(EntityTypeBuilder<Allergy> builder)
    {
        builder.ToTable("Allergies");
        base.Configure(builder);
        builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Type).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Severity).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Symptoms).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Treatment).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Notes).IsRequired().HasMaxLength(100);
    }
}