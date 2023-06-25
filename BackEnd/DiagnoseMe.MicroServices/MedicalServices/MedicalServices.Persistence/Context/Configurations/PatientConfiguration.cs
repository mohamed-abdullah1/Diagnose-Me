using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalServices.Persistence.Context.Configurations;

public class PatientConfiguration : BaseConfiguration<Patient>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");
        base.Configure(builder);
        builder.Property(p => p.Height);
        builder.Property(p => p.Weight);
        builder.HasMany(p => p.Doctors).
            WithMany(d => d.Patients).
            UsingEntity<PatientDoctor>(
                dp => dp.HasOne(d => d.Doctor).
                    WithMany().
                    HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade),
                dp => dp.HasOne(p => p.Patient).
                    WithMany().
                    HasForeignKey(p => p.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(p => p.Allergies).
            WithMany(a => a.Patients).
            UsingEntity<PatientAllergy>(
                pa => pa.HasOne(a => a.Allergy).
                    WithMany().
                    HasForeignKey(a => a.AllergyId)
                    .OnDelete(DeleteBehavior.Cascade),
                pa => pa.HasOne(p => p.Patient).
                    WithMany().
                    HasForeignKey(p => p.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(p => p.Medications).
            WithMany(m => m.Patients).
            UsingEntity<PatientMedication>(
                pm => pm.HasOne(m => m.Medication).
                    WithMany().
                    HasForeignKey(m => m.MedicationId)
                    .OnDelete(DeleteBehavior.Cascade),
                pm => pm.HasOne(p => p.Patient).
                    WithMany().
                    HasForeignKey(p => p.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(p => p.Surgeries).
            WithMany(s => s.Patients).
            UsingEntity<PatientSurgery>(
                ps => ps.HasOne(s => s.Surgery).
                    WithMany().
                    HasForeignKey(s => s.SurgeryId)
                    .OnDelete(DeleteBehavior.Cascade),
                ps => ps.HasOne(p => p.Patient).
                    WithMany().
                    HasForeignKey(p => p.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(p => p.Diseases).
            WithMany(d => d.Patients).
            UsingEntity<PatientDisease>(
                pd => pd.HasOne(d => d.Disease).
                    WithMany().
                    HasForeignKey(d => d.DiseaseId)
                    .OnDelete(DeleteBehavior.Cascade),
                pd => pd.HasOne(p => p.Patient).
                    WithMany().
                    HasForeignKey(p => p.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}