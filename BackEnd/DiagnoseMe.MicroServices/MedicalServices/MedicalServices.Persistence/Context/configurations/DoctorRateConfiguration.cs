using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class DoctorRateConfiguration : BaseConfiguration<DoctorRate>
{
    public override void Configure(EntityTypeBuilder<DoctorRate> builder)
    {
        builder.ToTable("DoctorRates");
        builder.HasKey(dr => new {dr.DoctorId, dr.UserId});
        builder.Property(dr => dr.Rate).IsRequired();
        builder.Property(dr => dr.Comment).HasMaxLength(500).IsRequired(false);
        builder.Property(dr => dr.UserId).IsRequired();
        builder.Property(dr => dr.DoctorId).IsRequired();
        builder.HasOne(dr => dr.Doctor).WithMany(d => d.DoctorRates).HasForeignKey(dr => dr.DoctorId);
        builder.HasOne(dr => dr.User).WithMany(p => p.DoctorRates).HasForeignKey(dr => dr.UserId);
    }
}