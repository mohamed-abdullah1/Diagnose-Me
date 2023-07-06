using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class DiseaseSurgeryRepository : BaseRepo<DiseaseSurgery>, IDiseaseSurgeryRepository
{
    public DiseaseSurgeryRepository(DbContext context) : base(context)
    {
    }
}