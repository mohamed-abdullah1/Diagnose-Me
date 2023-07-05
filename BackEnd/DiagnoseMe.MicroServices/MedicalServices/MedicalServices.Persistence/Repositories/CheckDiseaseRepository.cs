using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class CheckDiseaseRepository : BaseRepo<CheckDisease>, ICheckDiseaseRepository
{
    public CheckDiseaseRepository(DbContext dbContext) : base(dbContext)
    {
    }
}