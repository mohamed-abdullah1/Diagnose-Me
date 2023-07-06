using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class CheckDiseaseConfiguration : BaseConfiguration<CheckDisease>
{
    public override void Configure(EntityTypeBuilder<CheckDisease> builder)
    {
        builder.ToTable("CheckDiseases");
        builder.HasKey(c => new { c.CheckId, c.DiseaseId });
        builder.Property(c => c.CheckId).IsRequired().HasMaxLength(50);
        builder.Property(c => c.DiseaseId).IsRequired().HasMaxLength(50);
    }
}