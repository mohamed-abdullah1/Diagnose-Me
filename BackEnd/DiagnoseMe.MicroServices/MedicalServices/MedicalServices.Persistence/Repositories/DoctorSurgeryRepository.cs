using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class DoctorSurgeryRepository : BaseRepo<DoctorSurgery>, IDoctorSurgeryRepository
{
    public DoctorSurgeryRepository(DbContext context) : base(context)
    {
    }
}