using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class SurgeryMedicationRepository : BaseRepo<SurgeryMedication>, ISurgeryMedicationRepository
{
    public SurgeryMedicationRepository(DbContext context) : base(context)
    {
    }
}