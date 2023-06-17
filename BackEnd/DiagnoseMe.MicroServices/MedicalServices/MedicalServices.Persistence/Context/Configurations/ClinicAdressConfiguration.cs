using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;


public class ClinicAddressConfiguration : BaseConfiguration<ClinicAddress>
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
        builder.Property(c => c.OpenTime).IsRequired();
        builder.Property(c => c.CloseTime).IsRequired();
        builder.Property(c => c.ClinicId).IsRequired();
        builder.Property(c => c.OwnerId).IsRequired();
        builder.Property(c => c.ProfilPictureUrl).IsRequired();
        builder.HasOne(c => c.Clinic).WithMany(c => c.ClinicAddresses).HasForeignKey(c => c.ClinicId);
        builder.HasOne(c => c.Owner).WithMany(c => c.OwnedClinicAddresses).HasForeignKey(c => c.OwnerId);
    }
}