using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;


public class MedicineRepository : BaseRepo<Medicine>, IMedicineRepository
{
    public MedicineRepository(DbContext context) : base(context)
    {
    }
}