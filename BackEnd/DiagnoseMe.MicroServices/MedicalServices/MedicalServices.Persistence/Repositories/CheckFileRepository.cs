using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class CheckFileRepository : BaseRepo<CheckFile>, ICheckFileRepository
{
    public CheckFileRepository(DbContext dbContext) : base(dbContext)
    {
    }
}