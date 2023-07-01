using Auth.Domain.Common.Users;
using Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Auth.Persistence.Context.Seeds;


public class DefaultDoctor
{
    internal static ApplicationUser DoctorUser(ConfigurationManager _config) {
        var user = new ApplicationUser
        {
            Id = Users.DoctorId,
            UserName = Users.Doctor,
            FirstName = Users.Doctor,
            LastName = "",
            DateOfBirth = new DateOnly(2000,4,26),
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            Email = "doctor@diagnose.me",
            NormalizedEmail = "doctor@diagnose.me",
            NormalizedUserName = Users.Doctor,
            IsDoctor = true
        };
        user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user,_config.GetValue<string>("DoctorPassword")!);
        return user;
    }
}