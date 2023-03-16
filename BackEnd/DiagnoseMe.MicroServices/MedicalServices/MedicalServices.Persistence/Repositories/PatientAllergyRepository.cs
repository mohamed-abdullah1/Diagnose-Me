using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;


public class PatientAllergyRepository : BaseRepo<PatientAllergy>, IPatientAllergyRepository
{
    public PatientAllergyRepository(DbContext context) : base(context)
    {
    }
}