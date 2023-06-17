using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class DoctorRateRepository : BaseRepo<DoctorRate>, IDoctorRateRepository
{
    public DoctorRateRepository(DbContext context) : base(context)
    {
    }
}