using MapsterMapper;

namespace Auth.Application.Authentication.Queries.GetUser;


public class GetUserQueryHandler : 
    BaseAuthenticationHandler,
    IRequestHandler<GetUserQuery, ErrorOr<ApplicationUserResponse>>
{
    private readonly IMapper _mapper;
    public GetUserQueryHandler(
        UserManager<ApplicationUser> userManager,
        IMapper mapper) : base(userManager){
        _mapper = mapper;
        }
    public async Task<ErrorOr<ApplicationUserResponse>> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(query.UserId);
        if (user == null)
            return Errors.User.Name.NotExists;
        return _mapper.Map<ApplicationUserResponse>(user);
    }
}