using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class CheckAllergyRepository : BaseRepo<CheckAllergy>, ICheckAllergyRepository
{
    public CheckAllergyRepository(DbContext dbContext) : base(dbContext)
    {
    }
}