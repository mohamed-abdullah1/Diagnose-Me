using MapsterMapper;

namespace Auth.Application.Authentication.Queries.GetUsersInRole;

public class GetUsersInRoleQueryHandler :
    BaseAuthenticationHandler,
    IRequestHandler<GetUsersInRoleQuery, ErrorOr<List<ApplicationUserResponse>>>
{
    private readonly IMapper _mapper;
    public GetUsersInRoleQueryHandler(
        UserManager<ApplicationUser> userManager,
        IMapper mapper): base(userManager){
        _mapper = mapper;
        }
    public async Task<ErrorOr<List<ApplicationUserResponse>>> Handle(GetUsersInRoleQuery query, CancellationToken cancellationToken)
    {
        
        var role = query.Role[0].ToString().ToUpper() + query.Role.Substring(1).ToLower();
        if (!Roles.AvailableRoles.Contains(role))
            return Errors.Role.RoleNotExist;
        
        var users = (await _userManager.
                    GetUsersInRoleAsync(role)).
                    OrderBy(u => u.UserName).
                    Skip((query.pageNumber -1)* 10).
                    Take(10).
                    AsParallel().
                    ToList();
        return  _mapper.Map<List<ApplicationUserResponse>>(users);
    }
}