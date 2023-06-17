using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class CheckMedicationRepository : BaseRepo<CheckMedication>, ICheckMedicationRepository
{
    public CheckMedicationRepository(DbContext dbContext) : base(dbContext)
    {
    }
}