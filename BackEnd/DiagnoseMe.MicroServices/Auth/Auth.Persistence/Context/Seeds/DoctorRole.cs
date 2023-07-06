using Auth.Domain.Common.Roles;
using Auth.Domain.Common.Users;
using Microsoft.AspNetCore.Identity;

namespace Auth.Persistence.Context.Seeds;


public  class DefaultDoctorRole
{

    
    internal static IdentityUserRole<string> Role=> new IdentityUserRole<string>{
        RoleId = Roles.DoctorId,
        UserId = Users.DoctorId
    };
}