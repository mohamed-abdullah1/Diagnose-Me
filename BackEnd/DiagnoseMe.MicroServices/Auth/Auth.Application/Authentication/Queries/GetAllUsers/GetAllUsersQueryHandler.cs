using MapsterMapper;

namespace Auth.Application.Authentication.Queries.GetAllUsers;

public class GetAllUsersQueryHandler :
    BaseAuthenticationHandler,
    IRequestHandler<GetAllUsersQuery, List<ApplicationUserResponse>>
{
    private readonly IMapper _mapper;
    public GetAllUsersQueryHandler(
        UserManager<ApplicationUser> userManager,
        IMapper mapper) : base(userManager){
        _mapper = mapper;
        }
    public async Task<List<ApplicationUserResponse>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var users = _userManager.
                    Users.
                    OrderBy(u => u.UserName).
                    AsParallel().
                    Skip((query.pageNumber -1)* 10).
                    Take(10).
                    ToList();
        
        return _mapper.Map<List<ApplicationUserResponse>>(users);
    }
    
}