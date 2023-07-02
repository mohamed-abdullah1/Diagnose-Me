using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;
public class CheckSurgeryRepository : BaseRepo<CheckSurgery>, ICheckSurgeryRepository
{
    public CheckSurgeryRepository(DbContext dbContext) : base(dbContext)
    {
    }
}