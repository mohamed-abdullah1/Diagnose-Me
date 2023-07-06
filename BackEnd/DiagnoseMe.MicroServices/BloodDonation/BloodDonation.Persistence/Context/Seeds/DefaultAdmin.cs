using System.Reflection.Metadata;
using  BloodDonation.Domain.Entities;
using BloodDonation.Domain.Common.Users;
namespace BloodDonation.Persistence.Context.Seeds;

public class DefaultAdmin
{
 
    internal static User AdminUser() {
        var user = new User
        {
            Id = Users.AdminId,
            Name = Users.Admin,
            FullName = Users.Admin,
            ProfilePictureUrl = "",
            BloodType = "A+"      
        };
        return user;
    }
}