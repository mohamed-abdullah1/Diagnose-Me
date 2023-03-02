using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class MedicalRecordRepository : BaseRepo<MedicalRecord>, IMedicalRecordRepository
{
    public MedicalRecordRepository(DbContext context) : base(context)
    {
    }
}