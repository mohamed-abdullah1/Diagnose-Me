using System.Reflection.Metadata;
using  MedicalBlog.Domain.Entities;
using MedicalBlog.Domain.Common.Users;
namespace MedicalBlog.Persistence.Context.Seeds;

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