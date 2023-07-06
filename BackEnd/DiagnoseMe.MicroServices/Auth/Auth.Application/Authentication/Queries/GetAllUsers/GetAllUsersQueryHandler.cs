using MapsterMapper;

namespace Auth.Application.Authentication.Queries.GetAllUsers;

public class GetAllUsersQueryHandler :
    BaseAuthenticationHandler,
    IRequestHandler<GetAllUsersQuery, PageResponse>
{
    private readonly IMapper _mapper;
    public GetAllUsersQueryHandler(
        UserManager<ApplicationUser> userManager,
        IMapper mapper) : base(userManager){
        _mapper = mapper;
        }
    public async Task<PageResponse> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var users = _userManager.
                    Users.
                    OrderBy(u => u.UserName).
                    ToList();
        var IsNextPage = users.Count() > query.pageNumber * 10;
        var resUsers = users.
                    Skip((query.pageNumber -1)* 10).
                    Take(10).
                    ToList();
        var usersResponse = _mapper.Map<List<ApplicationUserResponse>>(resUsers);
        return new PageResponse(
            usersResponse.Select(u => (object)u).ToList(),
            query.pageNumber,
            IsNextPage
        );
    }
    
}