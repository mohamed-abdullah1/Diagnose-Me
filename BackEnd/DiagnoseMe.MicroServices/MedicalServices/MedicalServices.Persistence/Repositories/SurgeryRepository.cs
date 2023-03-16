using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;


public class SurgeryRepository : BaseRepo<Surgery>, ISurgeryRepository
{
    public SurgeryRepository(DbContext context) : base(context)
    {
    }
}