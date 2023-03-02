using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class ClinicPhoneNumberRepository : BaseRepo<ClinicPhoneNumber>, IClinicPhoneNumberRepository
{
    public ClinicPhoneNumberRepository(DbContext context) : base(context)
    {
    }
}