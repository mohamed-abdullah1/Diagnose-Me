using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;


public class ClinicAddressRepository : BaseRepo<ClinicAddress>, IClinicAddressRepository
{
    public ClinicAddressRepository(DbContext context) : base(context)
    {
    }
}