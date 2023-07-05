using MedicalBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace MedicalBlog.Persistence.Context.Seeds;
public static class Seed
{
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(DefaultPatient.PatientUser());
        modelBuilder.Entity<User>().HasData(DefaultDoctor.DoctorUser());
        modelBuilder.Entity<User>().HasData(DefaultAdmin.AdminUser());
        return modelBuilder;
    }
}