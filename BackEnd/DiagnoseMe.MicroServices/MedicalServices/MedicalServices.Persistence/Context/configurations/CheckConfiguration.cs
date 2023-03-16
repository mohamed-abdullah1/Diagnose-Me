using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class CheckConfiguration : BaseConfiguration<Check>
{
    public override void Configure(EntityTypeBuilder<Check> builder)
    {
        builder.ToTable("Checks");
        base.Configure(builder);
        builder.Property(c => c.MedicalRecordId).IsRequired();
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Type).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Data).IsRequired().HasMaxLength(500);
        builder.Property(c => c.Report).IsRequired().HasMaxLength(500);
    }
}