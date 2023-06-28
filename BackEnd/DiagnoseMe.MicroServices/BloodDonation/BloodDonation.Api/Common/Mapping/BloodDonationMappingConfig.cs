using BloodDonation.Application.BloodDonation.Commands.RequestDonation;
using BloodDonation.Domain.Entities;
using Mapster;

namespace BloodDonation.Api.Common.Mapping;

public class BloodDonationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(DonationRequest request, string userId), RequestDonationCommand>().
        Map(dest => dest.RequesterId, src => src.userId).
        Map(dest => dest, src => src.request);

    }
}