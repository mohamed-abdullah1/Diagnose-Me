using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class DiseaseMedicationRepository : BaseRepo<DiseaseMedication>, IDiseaseMedicationRepository
{
    public DiseaseMedicationRepository(DbContext context) : base(context)
    {
    }
}