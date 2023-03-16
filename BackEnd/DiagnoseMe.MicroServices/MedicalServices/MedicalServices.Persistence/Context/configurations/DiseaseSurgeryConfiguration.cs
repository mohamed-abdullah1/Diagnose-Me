using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.configurations;

public class DiseaseSurgeryConfiguration : BaseConfiguration<DiseaseSurgery>
{
    public override void Configure(EntityTypeBuilder<DiseaseSurgery> builder)
    {
        builder.ToTable("DiseaseSurgeries");
        builder.HasKey(ds => new {ds.DiseaseId, ds.SurgeryId});
        builder.Property(ds => ds.DiseaseId).IsRequired().HasMaxLength(100);
        builder.Property(ds => ds.SurgeryId).IsRequired().HasMaxLength(100);

    }
}