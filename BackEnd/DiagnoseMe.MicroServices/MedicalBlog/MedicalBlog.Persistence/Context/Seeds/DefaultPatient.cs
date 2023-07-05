using System.Reflection.Metadata;
using  MedicalBlog.Domain.Entities;
using MedicalBlog.Domain.Common.Users;
namespace MedicalBlog.Persistence.Context.Seeds;

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
}