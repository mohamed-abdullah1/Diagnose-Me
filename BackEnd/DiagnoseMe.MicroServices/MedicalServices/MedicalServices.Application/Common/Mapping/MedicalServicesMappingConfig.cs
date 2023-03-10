
using Mapster;
using MedicalServices.Application.Clinics.Common;

namespace MedicalServices.Api.Common.Mapping;

public class MedicalServicesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Clinic, ClinicResponse>().
        Map(dest => dest.DoctorsCount, src => src.Doctors.Count).
        Map(dest => dest.ClinicAddressesCount, src => src.ClinicAddresses.Count).
        Map(dest => dest, src => src);
        config.NewConfig<Doctor, DoctorResponse>().
        Map(dest => dest, src => src.User).
        Map(dest => dest, src => src);
    }
}