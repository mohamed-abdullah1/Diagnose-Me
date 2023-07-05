using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;


public class PatientMedicationConfiguration : BaseConfiguration<PatientMedication>
{
    public override void Configure(EntityTypeBuilder<PatientMedication> builder)
    {
        builder.ToTable("PatientMedications");
        builder.HasKey(pm => new {pm.PatientId, pm.MedicationId});
        builder.Property(pm => pm.PatientId).IsRequired().HasMaxLength(100);
        builder.Property(pm => pm.MedicationId).IsRequired().HasMaxLength(100);
    }
}