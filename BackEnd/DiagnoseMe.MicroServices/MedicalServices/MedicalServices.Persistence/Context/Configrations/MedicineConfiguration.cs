using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configrations;

public class MedicineConfiguration : BaseConfiguration<Medicine>
{
    public override void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.ToTable("Medicines");
        base.Configure(builder);
        builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Dose).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Concentration).IsRequired().HasMaxLength(500);
        builder.Property(m => m.Type).IsRequired();
        builder.HasOne(m => m.MedicalRecord).WithMany(m => m.Medicines).HasForeignKey(m => m.MedicalRecordId);
    }
}