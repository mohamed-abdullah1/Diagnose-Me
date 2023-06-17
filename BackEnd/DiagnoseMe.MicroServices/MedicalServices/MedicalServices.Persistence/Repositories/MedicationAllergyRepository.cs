using System.Data.Common;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;


public class MedicationAllergyRepository : BaseRepo<MedicationAllergy>, IMedicationAllergyRepository
{
    public MedicationAllergyRepository(DbContext context) : base(context)
    {
    }
}