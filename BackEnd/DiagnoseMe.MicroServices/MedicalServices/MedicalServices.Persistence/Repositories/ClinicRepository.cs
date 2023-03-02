using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class ClinicRepository : BaseRepo<Clinic>, IClinicRepository
{
    public ClinicRepository(DbContext context) : base(context)
    {
    }
}