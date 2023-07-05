using Auth.Domain.Common.Users;
using Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Auth.Persistence.Context.Seeds;


public class DefaultPatient
{
    internal static ApplicationUser PatientUser(ConfigurationManager _config) {
        var user = new ApplicationUser
        {
            Id = Users.PatientId,
            UserName = Users.Patient,
            FirstName = Users.Patient,
            LastName = "",
            DateOfBirth = new DateOnly(2000,4,26),
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            Email = "patient@diagnose.me",
            NormalizedEmail = "patient@diagnose.me",
            NormalizedUserName = Users.Patient
        };
        user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user,_config.GetValue<string>("PatientPassword")!);
        return user;
    }
}