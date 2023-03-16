namespace MedicalServices.Persistence.Context.Configurations;

using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PatientDoctorConfiguration : IEntityTypeConfiguration<PatientDoctor>
{
    public void Configure(EntityTypeBuilder<PatientDoctor> builder)
    {
        builder.ToTable("PatientDoctors");
        builder.HasKey(pd => new {pd.PatientId, pd.DoctorId});
    }
}