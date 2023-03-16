
using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        base.Configure(builder);
        builder.Property(u => u.Name).IsRequired();
        builder.Property(u => u.FullName).IsRequired();
        builder.Property(u => u.ProfilePictureUrl).IsRequired();
        builder.Property(u => u.IsDoctor).IsRequired();
        builder.HasOne(u => u.Doctor).WithOne(d => d.User).HasForeignKey<Doctor>(d => d.Id);
        builder.HasOne(u => u.Patient).WithOne(p => p.User).HasForeignKey<Patient>(p => p.Id);
    }
}