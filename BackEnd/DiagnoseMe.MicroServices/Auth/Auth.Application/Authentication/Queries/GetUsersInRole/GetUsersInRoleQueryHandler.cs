using MapsterMapper;

namespace Auth.Application.Authentication.Queries.GetUsersInRole;

public class GetUsersInRoleQueryHandler :
    BaseAuthenticationHandler,
    IRequestHandler<GetUsersInRoleQuery, ErrorOr<PageResponse>>
{
    private readonly IMapper _mapper;
    public GetUsersInRoleQueryHandler(
        UserManager<ApplicationUser> userManager,
        IMapper mapper): base(userManager){
        _mapper = mapper;
        }
    public async Task<ErrorOr<PageResponse>> Handle(GetUsersInRoleQuery query, CancellationToken cancellationToken)
    {
        
        var role = query.Role[0].ToString().ToUpper() + query.Role.Substring(1).ToLower();
        if (!Roles.AvailableRoles.Contains(role))
            return Errors.Role.RoleNotExist;
        
        var users = (await _userManager.
                    GetUsersInRoleAsync(role)).
                    OrderBy(u => u.UserName).
                    ToList();
                    
        if (role == Roles.User)
            users =  users.Where(x => !x.IsDoctor).ToList();
            
        var IsNextPage = users.Count() > query.pageNumber * 10;
        var resUsers = users.
                    Skip((query.pageNumber -1)* 10).
                    Take(10).
                    ToList();
        var usersResponse = _mapper.Map<List<ApplicationUserResponse>>(resUsers);
        return  new PageResponse(
            usersResponse.Select(u => (object)u).ToList(),
            query.pageNumber,
            IsNextPage
        );
    }
}