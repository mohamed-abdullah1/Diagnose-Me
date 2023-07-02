using System;
using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;


public class ClinicConfiguration : BaseConfiguration<Clinic>
{
    public override void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.ToTable("Clinics");
        base.Configure(builder);
        builder.Property(c => c.Specialization).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Description).IsRequired().HasMaxLength(50);
        builder.Property(c => c.PictureUrl).IsRequired();
    }
}