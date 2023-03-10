using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configrations;


public class ClinicAddressConfigration : BaseConfiguration<ClinicAddress>
{
    public override void Configure(EntityTypeBuilder<ClinicAddress> builder)
    {
        builder.ToTable("ClinicAddresses");
        base.Configure(builder);
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.City).IsRequired();
        builder.Property(c => c.Street).IsRequired();
        builder.Property(c => c.State).IsRequired();
        builder.Property(c => c.Country).IsRequired();
        builder.Property(c => c.ZipCode).IsRequired();
        builder.Property(c => c.ClinicId).IsRequired();
        builder.Property(c => c.ProfilPictureUrl).IsRequired();
        builder.HasOne(c => c.Clinic).WithMany(c => c.ClinicAddresses).HasForeignKey(c => c.ClinicId);
    }
}