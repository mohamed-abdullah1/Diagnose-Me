namespace Auth.Application.Authentication.Queries.GetIfUsernameExist;

public class GetIfUsernameExistQueryHandler : IRequestHandler<GetIfUsernameExistQuery, bool>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public GetIfUsernameExistQueryHandler(
        UserManager<ApplicationUser> userManager
    )
    {
        _userManager = userManager;
    }
    public async Task<bool> Handle(GetIfUsernameExistQuery query, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(query.Username);
        if (user == null)
            return false;
        return true;
    }
}