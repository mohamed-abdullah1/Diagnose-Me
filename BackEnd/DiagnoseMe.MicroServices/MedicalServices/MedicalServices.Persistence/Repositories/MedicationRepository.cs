using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;


public class MedicationRepository : BaseRepo<Medication>, IMedicationRepository
{
    public MedicationRepository(DbContext context) : base(context)
    {
    }
}