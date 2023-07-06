using System.Reflection.Metadata;
using  MedicalServices.Domain.Entities;
using MedicalServices.Domain.Common.Users;
namespace MedicalServices.Persistence.Context.Seeds;

public class DefaultPatient
{
 
    internal static User PatientUser() {
        var user = new User
        {
            Id = Users.PatientId,
            Name = Users.Patient,
            FullName = Users.Patient,
            ProfilePictureUrl = "",
        };
        return user;
    }
    internal static Patient Patient(){
        var patient= new Patient{
            Id = Users.PatientId,
            Weight = 70,
            Height = 1.70F
        };
        return patient;
    }
    
}