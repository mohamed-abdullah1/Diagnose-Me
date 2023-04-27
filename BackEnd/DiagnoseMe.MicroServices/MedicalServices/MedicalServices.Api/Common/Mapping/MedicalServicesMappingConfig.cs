using Mapster;
using MedicalServices.Application.MedicalServices.Clinics.Commands.AddClinicAddress;
using MedicalServices.Application.MedicalServices.Clinics.Commands.UpdateClinicAddress;
using MedicalServices.Application.MedicalServices.Doctors.Commands.AddDoctor;
using MedicalServices.Application.MedicalServices.Doctors.Commands.AddDoctorRate;
using MedicalServices.Application.MedicalServices.Doctors.Commands.UpdateDoctor;
using MedicalServices.Contracts.Clinics;
using MedicalServices.Contracts.Doctors;

namespace MedicalServices.Api.Common.Mapping;

public class MedicalServicesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(AddClinicAddressRequest request, string OwnerId),AddClinicAddressCommand>().
                    Map(dest => dest.OwnerId, src => src.OwnerId).
                    Map(dest => dest, src => src.request);
        config.NewConfig<(UpdateClinicAddressRequest request, string DoctorId),UpdateClinicAddressCommand>().
                    Map(dest => dest.DoctorId, src => src.DoctorId).
                    Map(dest => dest, src => src.request);
        config.NewConfig<(AddDoctorRequest request, string UserId),AddDoctorCommand>().
                    Map(dest => dest.UserId, src => src.UserId).
                    Map(dest => dest, src => src.request);
        config.NewConfig<(UpdateDoctorRequest request, string DoctorId),UpdateDoctorCommand>().
                    Map(dest => dest.DoctorId, src => src.DoctorId).
                    Map(dest => dest, src => src.request);
        config.NewConfig<(AddDoctorRateRequest request, string UserId),AddDoctorRateCommand>().
                    Map(dest => dest.UserId, src => src.UserId).
                    Map(dest => dest, src => src.request);

    }
}
