using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class PatientMedicationRepository : BaseRepo<PatientMedication>, IPatientMedicationRepository
{
    public PatientMedicationRepository(DbContext context) : base(context)
    {
    }
}