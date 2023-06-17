using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class DoctorMedicationRepository : BaseRepo<DoctorMedication>, IDoctorMedicationRepository
{
    public DoctorMedicationRepository(DbContext context) : base(context)
    {
    }
}