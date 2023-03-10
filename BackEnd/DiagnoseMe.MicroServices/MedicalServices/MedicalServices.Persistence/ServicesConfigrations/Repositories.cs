using MedicalServices.Application.Common.Interfaces.Persistence;
using MedicalServices.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalServices.Persistence.ServicesConfigrations;

public static class Repositories
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
        {
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<ICheckRepository, CheckRepository>();
            services.AddScoped<IDoctorRateRepository, DoctorRateRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IPatientDoctorRepository, PatientDoctorRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IClinicAddressRepository,ClinicAddressRepository>();
            services.AddScoped<IDoctorClinicAddressRepository,DoctorClinicAddressRepository>();
            return services;
        }
}