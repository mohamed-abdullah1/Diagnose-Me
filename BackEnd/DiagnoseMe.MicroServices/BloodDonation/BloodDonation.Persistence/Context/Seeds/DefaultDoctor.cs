using System.Reflection.Metadata;
using  BloodDonation.Domain.Entities;
using BloodDonation.Domain.Common.Users;
namespace BloodDonation.Persistence.Context.Seeds;

public class DefaultDoctor
{
 
    internal static User DoctorUser() {
        var user = new User
        {
            Id = Users.DoctorId,
            Name = Users.Doctor,
            FullName = Users.Doctor,
            ProfilePictureUrl = "",
            BloodType = "A+"      
        };
        return user;
    }
}