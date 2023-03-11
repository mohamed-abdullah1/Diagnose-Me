using Auth.Domain.Common.Users;
using Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Auth.Persistence.Context.Seeds;


public class DefaultAdmin
{
 
    internal static ApplicationUser AdminUser(ConfigurationManager _config) {
        var user = new ApplicationUser
        {
            Id = Users.AdminId,
            UserName = Users.Admin,
            FirstName = Users.Admin,
            LastName = "",
            DateOfBirth = new DateOnly(2000,4,26),
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            Email = "admin@diagnose.me",
            NormalizedEmail = "admin@diagnose.me",
            NormalizedUserName = Users.Admin
        };
        user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user,_config.GetValue<string>("AdminPassword")!);
        return user;
    }

}