using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class CheckRepository : BaseRepo<Check>, ICheckRepository
{
    public CheckRepository(DbContext db) : base(db)
    {
    }
}