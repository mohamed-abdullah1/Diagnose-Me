using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace MedicalServices.Persistence.Context.Seeds;
public static class Seed
{
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(DefaultPatient.PatientUser());
        modelBuilder.Entity<Patient>().HasData(DefaultPatient.Patient());
        modelBuilder.Entity<User>().HasData(DefaultDoctor.DoctorUser());
        modelBuilder.Entity<Doctor>().HasData(DefaultDoctor.Doctor());
        modelBuilder.Entity<Clinic>().HasData(DefaultClinic.Clinic());
        modelBuilder.Entity<User>().HasData(DefaultAdmin.AdminUser());
        return modelBuilder;
    }
}