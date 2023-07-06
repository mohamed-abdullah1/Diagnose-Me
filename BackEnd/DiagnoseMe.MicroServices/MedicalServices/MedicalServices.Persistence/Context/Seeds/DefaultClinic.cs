using MedicalServices.Domain.Common.Clinics;
using MedicalServices.Domain.Entities;

namespace MedicalServices.Persistence.Context.Seeds;


public class DefaultClinic
{
    internal static Clinic Clinic()
    {
        var clinic = new Clinic
        {
            Id = Clinics.DentalId,
            Specialization = Clinics.Dental,
            Description = "Dental Clinic",
            PictureUrl = ""

        };
        return clinic;
    }
}