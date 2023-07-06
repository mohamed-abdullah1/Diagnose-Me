namespace Auth.Application.Authentication.Queries.GetIfEmailExist;

public class GetIfEmailExistQueryHandler : IRequestHandler<GetIfEmailExistQuery, bool>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public GetIfEmailExistQueryHandler(
        UserManager<ApplicationUser> userManager
    )
    {
        _userManager = userManager;
    }
    public async Task<bool> Handle(GetIfEmailExistQuery query, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(query.Email);
        if (user == null)
            return false;
        return true;
    }
}