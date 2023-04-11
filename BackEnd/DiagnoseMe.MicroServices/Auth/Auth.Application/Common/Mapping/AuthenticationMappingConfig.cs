
using Mapster;

namespace Auth.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ApplicationUser,ApplicationUserResponse>().
                    Map(dest => dest.Name, src => src.UserName).
                    Map(dest => dest.FullName , src => $"{src.FirstName} {src.LastName}").
                    Map(dest => dest.DateOfBirth, src => src.DateOfBirth.ToString()).
                    Map(dest => dest, src => src);
    }
}