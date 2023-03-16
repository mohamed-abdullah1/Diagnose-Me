using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.configurations;

public class DiseaseMedicationConfiguration : BaseConfiguration<DiseaseMedication>
{
    public override void Configure(EntityTypeBuilder<DiseaseMedication> builder)
    {
        builder.ToTable("DiseaseMedications");
        builder.HasKey(dm => new {dm.DiseaseId, dm.MedicationId});
        builder.Property(dm => dm.DiseaseId).IsRequired().HasMaxLength(100);
        builder.Property(dm => dm.MedicationId).IsRequired().HasMaxLength(100);
    }
}