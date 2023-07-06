using MapsterMapper;

namespace Auth.Application.Authentication.Queries.GetToken;

public class GetTokenQueryHandler: 
    BaseAuthenticationHandler,
    IRequestHandler<GetTokenQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IMapper _mapper;

    public GetTokenQueryHandler(
        UserManager<ApplicationUser> userManager,
        IJwtTokenGenerator jwtTokenGenerator,
        IMapper mapper
    ): base(userManager)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _mapper = mapper;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(GetTokenQuery query, CancellationToken cancellationToken)
    {
        AuthenticationResult results = new AuthenticationResult();
        var user = await _userManager.FindByEmailAsync(query.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, query.Password))
            return Errors.User.Credential.Invalid;
 
        if (!user.EmailConfirmed)
            return Errors.User.Email.NotConfirmed;
            
        results.Message = "Signed in successfully";
        results.Username = user.UserName;
        results.Token = "Bearer " + (new JwtSecurityTokenHandler().WriteToken(_jwtTokenGenerator
            .GenerateJwtTokenAsync(
            user.Id,
            user.UserName!,
            await GetUserClaims(user))));
        results.User =  _mapper.Map<ApplicationUserResponse>(user);
        return results;
    }
}