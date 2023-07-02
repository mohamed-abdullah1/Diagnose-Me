using System.Reflection.Metadata;
using  BloodDonation.Domain.Entities;
using BloodDonation.Domain.Common.Users;
namespace BloodDonation.Persistence.Context.Seeds;

public class DefaultPatient
{
 
    internal static User PatientUser() {
        var user = new User
        {
            Id = Users.PatientId,
            Name = Users.Patient,
            FullName = Users.Patient,
            ProfilePictureUrl = "",
            BloodType = "A+"      
        };
        return user;
    }
}