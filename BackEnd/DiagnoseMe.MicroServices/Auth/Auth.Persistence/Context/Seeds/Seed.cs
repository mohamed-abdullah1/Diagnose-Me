using Auth.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Auth.Persistence.Context.Seeds;
public static class Seed
{
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        var builder = WebApplication.CreateBuilder();
        var configuration = builder.Configuration;
        configuration.AddUserSecrets(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Entity<IdentityRole>().HasData(DefaultRoles.IdentityRoleList());
        modelBuilder.Entity<ApplicationUser>().HasData(DefaultAdmin.AdminUser(configuration));
        modelBuilder.Entity<ApplicationUser>().HasData(DefaultDoctor.DoctorUser(configuration));
        modelBuilder.Entity<ApplicationUser>().HasData(DefaultPatient.PatientUser(configuration));
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(DefaultAdminRole.Role);
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(DefaultDoctorRole.Role);
        return modelBuilder;
    }
}