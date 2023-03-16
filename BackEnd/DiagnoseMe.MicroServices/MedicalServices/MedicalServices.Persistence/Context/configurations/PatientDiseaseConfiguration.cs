using MedicalServices.Domain.Entities;
using MedicalServices.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.configurations;


public class PatientDiseaseConfiguration : BaseConfiguration<PatientDisease>
{
    public override void Configure(EntityTypeBuilder<PatientDisease> builder)
    {
        builder.ToTable("PatientDiseases");
        builder.HasKey(pd => new {pd.PatientId, pd.DiseaseId});
        builder.Property(pd => pd.PatientId).IsRequired().HasMaxLength(100);
        builder.Property(pd => pd.DiseaseId).IsRequired().HasMaxLength(100);
    }
}