using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class DiseaseAllergyRepository : BaseRepo<DiseaseAllergy>, IDiseaseAllergyRepository
{
    public DiseaseAllergyRepository(DbContext context) : base(context)
    {
    }
}