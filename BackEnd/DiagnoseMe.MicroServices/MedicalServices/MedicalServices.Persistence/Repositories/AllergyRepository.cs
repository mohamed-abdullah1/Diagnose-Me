using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class AllergyRepository : BaseRepo<Allergy>, IAllergyRepository
{
    public AllergyRepository(DbContext context) : base(context)
    {
    }
}