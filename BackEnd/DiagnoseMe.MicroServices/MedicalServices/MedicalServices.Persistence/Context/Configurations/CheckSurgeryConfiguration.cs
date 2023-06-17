using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class CheckSurgeryConfiguration : BaseConfiguration<CheckSurgery>
{
    public override void Configure(EntityTypeBuilder<CheckSurgery> builder)
    {
        builder.ToTable("CheckSurgery");
        builder.HasKey(x => new { x.SurgeryId, x.CheckId });
        builder.Property(x => x.SurgeryId).IsRequired();
        builder.Property(x => x.CheckId).IsRequired();
    }
}