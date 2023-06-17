using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;


public class DoctorRepository : BaseRepo<Doctor>, IDoctorRepository
{
    public DoctorRepository(DbContext context) : base(context)
    {
    }
}