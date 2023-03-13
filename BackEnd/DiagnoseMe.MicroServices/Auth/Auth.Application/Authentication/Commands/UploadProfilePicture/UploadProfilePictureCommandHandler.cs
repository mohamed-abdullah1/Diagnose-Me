using Auth.Application.Authentication.Helpers;
using Auth.Application.Common.Interfaces.Services;
using FileTypeChecker.Extensions;

namespace Auth.Application.Authentication.Commands.UploadProfilePicture;

public class ResetPasswordCommandHandle :
    BaseAuthenticationHandler,
    IRequestHandler<UploadProfilePictureCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IFileHandler _fileHandler;
    public ResetPasswordCommandHandle(
        UserManager<ApplicationUser> userManager,
        IFileHandler fileHandler): base(userManager){
            _fileHandler = fileHandler;
        }
    public async Task<ErrorOr<AuthenticationResult>> Handle(UploadProfilePictureCommand command, CancellationToken cancellationToken)
    {


            
            var user = await _userManager.FindByNameAsync(command.UserName);
            if (user == null)
                return (Errors.User.Name.NotExists);
            var result = SaveFile.SavePicture(command.Base64Picture, _fileHandler);  
            if (result.IsError)
                return (result.Errors);
                  
            user!.ProfilePictureUrl = result.Value;
            var updateResult = await _userManager.UpdateAsync(user);
            
        return (
            new AuthenticationResult{
                Message = "Profile picture have been successfully changed"});
   }
}