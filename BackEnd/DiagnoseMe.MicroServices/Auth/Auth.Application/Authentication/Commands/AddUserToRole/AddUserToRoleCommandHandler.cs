namespace Auth.Application.Authentication.Commands.AddUserToRole;

public class AddUserToRoleCommandHandler :
    BaseAuthenticationHandler,
    IRequestHandler<AddUserToRoleCommand, ErrorOr<AuthenticationResult>>
{
    public AddUserToRoleCommandHandler(
        UserManager<ApplicationUser> userManager
    ): base(userManager){}

    public async Task<ErrorOr<AuthenticationResult>> Handle(AddUserToRoleCommand command, CancellationToken cancellationToken)
    {
        var results = new AuthenticationResult();
        var role = command.Role[0].ToString().ToUpper() + command.Role.Substring(1).ToLower();
        if (!Roles.AvailableRoles.Contains(role))
            return Errors.Role.RoleNotExist;

        var user = await _userManager.FindByNameAsync(command.UserName);
        if (user == null)
            return Errors.User.Name.NotExists;

        var result = await _userManager.AddToRoleAsync(user, role);
        if(!result.Succeeded)
            return Errors.User.MapIdentityError(result.Errors.ToList());

        results.Message = $"User is successfully added to {command.Role} role";
        return results;
    }
}