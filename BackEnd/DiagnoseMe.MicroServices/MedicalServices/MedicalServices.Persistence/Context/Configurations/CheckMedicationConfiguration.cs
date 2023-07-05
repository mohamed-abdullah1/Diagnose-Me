using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class CheckMedicationConfiguration : BaseConfiguration<CheckMedication>
{
    public override void Configure(EntityTypeBuilder<CheckMedication> builder)
    {
        builder.ToTable("CheckMedication");
        builder.HasKey(x => new { x.MedicationId, x.CheckId });
        builder.Property(x => x.MedicationId).IsRequired();
        builder.Property(x => x.CheckId).IsRequired();

    }
}