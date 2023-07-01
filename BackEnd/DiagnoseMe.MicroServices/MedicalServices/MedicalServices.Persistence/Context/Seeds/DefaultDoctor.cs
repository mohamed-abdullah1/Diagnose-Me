using System.Reflection.Metadata;
using  MedicalServices.Domain.Entities;
using MedicalServices.Domain.Common.Users;
using MedicalServices.Domain.Common.Clinics;

namespace MedicalServices.Persistence.Context.Seeds;

public class DefaultDoctor
{
 
    internal static User DoctorUser() {
        var user = new User
        {
            Id = Users.DoctorId,
            Name = Users.Doctor,
            FullName = Users.Doctor,
            ProfilePictureUrl = "",
            IsDoctor = true
        };
        return user;
    }
    internal static Doctor Doctor(){
        var doctor= new Doctor{
            Id = Users.DoctorId,
            Title = "Dr",
            Bio = "I am a doctor",
            License = "123456789",
            IsLicenseVerified = true,
            ClinicId = Clinics.DentalId
        };
        return doctor;
    }
}