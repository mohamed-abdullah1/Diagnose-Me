using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class CheckFileConfiguration : BaseConfiguration<CheckFile>
{

    public override void Configure(EntityTypeBuilder<CheckFile> builder)
    {
        builder.ToTable("CheckFiles");
        base.Configure(builder);
        builder.Property(c => c.CheckId).IsRequired().HasMaxLength(50);
        builder.Property(c => c.FileUrl).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Type).IsRequired().HasMaxLength(50);
        builder.HasOne(c => c.Check).WithMany(c => c.CheckFiles).HasForeignKey(c => c.CheckId);

    }
}