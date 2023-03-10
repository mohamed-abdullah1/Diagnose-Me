using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.Persistence.Repositories;

public class DoctorClinicAddressRepository : BaseRepo<DoctorClinicAddress>, IDoctorClinicAddressRepository
{
    public DoctorClinicAddressRepository(DbContext context) : base(context)
    {
    }
}