using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;



public class SurgeryMedicationConfiguration : BaseConfiguration<SurgeryMedication>
{
    public override void Configure(EntityTypeBuilder<SurgeryMedication> builder)
    {
        builder.ToTable("SurgeryMedications");
        builder.HasKey(sm => new {sm.SurgeryId, sm.MedicationId});
        builder.Property(sm => sm.SurgeryId).IsRequired().HasMaxLength(100);
        builder.Property(sm => sm.MedicationId).IsRequired().HasMaxLength(100);
    }
}