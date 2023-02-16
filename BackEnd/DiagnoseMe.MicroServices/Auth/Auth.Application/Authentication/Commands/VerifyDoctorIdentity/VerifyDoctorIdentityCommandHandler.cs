using Auth.Application.Common.Interfaces.AI;

namespace Auth.Application.Authentication.Commands.VerifyDoctorIdentity;


public class VerifyDoctorIdentityCommandHandler: 
    BaseAuthenticationHandler,
    IRequestHandler<VerifyDoctorIdentityCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IDoctorIdentifyService _doctorIdentifyService;
    public VerifyDoctorIdentityCommandHandler(
        UserManager<ApplicationUser> userManager,
        IDoctorIdentifyService doctorIdentifyService
    ): base(userManager)
    {
        _doctorIdentifyService = doctorIdentifyService;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(VerifyDoctorIdentityCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(command.UserName);
       
        var result = await _doctorIdentifyService.CheckIfDoctor(command.Base64License);
        if(result.IsError)
            return result.Errors;
        
        user!.IsDoctor = result.Value;

        if(user.IsDoctor){
            var roleResult = await _userManager.AddToRoleAsync(user, Roles.Doctor);
            if(!roleResult.Succeeded)
                return Errors.User.MapIdentityError(roleResult.Errors.ToList());
        }
            
        var updateResult = await _userManager.UpdateAsync(user);
        if(!updateResult.Succeeded)
            return Errors.User.MapIdentityError(updateResult.Errors.ToList());
        
        return new AuthenticationResult{
            Message = $"User {user.UserName} is {(user.IsDoctor ? "doctor" : "not doctor")}",
            Username = user.UserName
        };
    }
}