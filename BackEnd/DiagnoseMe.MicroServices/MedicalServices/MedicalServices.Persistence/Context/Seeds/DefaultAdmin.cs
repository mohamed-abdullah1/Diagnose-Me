using System.Reflection.Metadata;
using  MedicalServices.Domain.Entities;
using MedicalServices.Domain.Common.Users;
namespace MedicalServices.Persistence.Context.Seeds;

public class DefaultAdmin
{
 
    internal static User AdminUser() {
        var user = new User
        {
            Id = Users.AdminId,
            Name = Users.Admin,
            FullName = Users.Admin,
            ProfilePictureUrl = "",
        };
        return user;
    }
}