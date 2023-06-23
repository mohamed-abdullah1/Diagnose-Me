using System.Reflection.Metadata;
using  MedicalBlog.Domain.Entities;
using MedicalBlog.Domain.Common.Users;
using MedicalBlog.Domain.Common.Specialities;

namespace MedicalBlog.Persistence.Context.Seeds;

public class DefaultDoctor
{
 
    internal static User DoctorUser() {
        var user = new User
        {
            Id = Users.DoctorId,
            Name = Users.Doctor,
            FullName = Users.Doctor,
            ProfilePictureUrl = "",
            Specialization = Specialities.Dental
        };
        return user;
    }
}