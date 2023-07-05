using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;


public class PatientRepository : BaseRepo<Patient>, IPatientRepository
{
    public PatientRepository(DbContext context) : base(context)
    {
    }
}