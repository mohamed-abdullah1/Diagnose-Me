using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.configurations;


public class DoctorMedicationConfiguration : BaseConfiguration<DoctorMedication>
{
    public override void Configure(EntityTypeBuilder<DoctorMedication> builder)
    {
        builder.ToTable("DoctorMedications");
        builder.HasKey(dm => new {dm.DoctorId, dm.MedicationId});
        builder.Property(dm => dm.DoctorId).IsRequired().HasMaxLength(100);
        builder.Property(dm => dm.MedicationId).IsRequired().HasMaxLength(100);
    }
}