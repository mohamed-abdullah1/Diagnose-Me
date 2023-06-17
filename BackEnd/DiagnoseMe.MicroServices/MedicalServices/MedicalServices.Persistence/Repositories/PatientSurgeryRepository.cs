using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class PatientSurgeryRepository : BaseRepo<PatientSurgery>, IPatientSurgeryRepository
{
    public PatientSurgeryRepository(DbContext context) : base(context)
    {
    }
}