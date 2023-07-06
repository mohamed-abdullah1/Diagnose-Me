using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalServices.Persistence.ServicesConfigurations;

public static class Repositories
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
        {
            // services.AddScoped(typeof(IBaseRepo<BaseEntity>), typeof(BaseRepo<BaseEntity>));
            services.AddScoped<IAllergyRepository,AllergyRepository>();
            services.AddScoped<ICheckRepository, CheckRepository>();
            services.AddScoped<IClinicAddressRepository, ClinicAddressRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IDiseaseAllergyRepository,DiseaseAllergyRepository>();
            services.AddScoped<IDiseaseMedicationRepository,DiseaseMedicationRepository>();
            services.AddScoped<IDiseaseRepository,DiseaseRepository>();
            services.AddScoped<IDiseaseSurgeryRepository,DiseaseSurgeryRepository>();
            services.AddScoped<IDoctorMedicationRepository,DoctorMedicationRepository>();
            services.AddScoped<IDoctorRateRepository,DoctorRateRepository>();
            services.AddScoped<IDoctorRepository,DoctorRepository>();
            services.AddScoped<IDoctorSurgeryRepository,DoctorSurgeryRepository>();
            services.AddScoped<IMedicationRepository,MedicationRepository>();
            services.AddScoped<IMedicationAllergyRepository,MedicationAllergyRepository>();
            services.AddScoped<IPatientAllergyRepository,PatientAllergyRepository>();
            services.AddScoped<IPatientDiseaseRepository,PatientDiseaseRepository>();
            services.AddScoped<IPatientDoctorRepository,PatientDoctorRepository>();
            services.AddScoped<IPatientMedicationRepository,PatientMedicationRepository>();
            services.AddScoped<IPatientRepository,PatientRepository>();
            services.AddScoped<IPatientSurgeryRepository,PatientSurgeryRepository>();
            services.AddScoped<ISurgeryRepository,SurgeryRepository>();
            services.AddScoped<ISurgeryAllergyRepository,SurgeryAllergyRepository>();
            services.AddScoped<ISurgeryMedicationRepository,SurgeryMedicationRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ICheckAllergyRepository,CheckAllergyRepository>();
            services.AddScoped<ICheckFileRepository,CheckFileRepository>();
            services.AddScoped<ICheckMedicationRepository,CheckMedicationRepository>();
            services.AddScoped<ICheckDiseaseRepository,CheckDiseaseRepository>();
            services.AddScoped<ICheckSurgeryRepository,CheckSurgeryRepository>();

            return services;
        }
}