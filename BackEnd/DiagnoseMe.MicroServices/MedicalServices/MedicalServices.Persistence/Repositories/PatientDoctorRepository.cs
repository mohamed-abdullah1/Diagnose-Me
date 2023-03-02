using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class PatientDoctorRepository : BaseRepo<PatientDoctor>, IPatientDoctorRepository
{
    public PatientDoctorRepository(DbContext context) : base(context)
    {
    }
}