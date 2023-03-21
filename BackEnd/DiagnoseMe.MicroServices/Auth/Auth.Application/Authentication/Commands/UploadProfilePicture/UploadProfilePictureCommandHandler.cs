using Auth.Application.Authentication.Helpers;
using Auth.Application.Common.Interfaces.RabbitMq;
using Auth.Application.Common.Interfaces.Services;
using FileTypeChecker.Extensions;
using MapsterMapper;

namespace Auth.Application.Authentication.Commands.UploadProfilePicture;

public class ResetPasswordCommandHandle :
    BaseAuthenticationHandler,
    IRequestHandler<UploadProfilePictureCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IFileHandler _fileHandler;
    private readonly IMapper _mapper;
    private readonly IMessageQueueManager _messageQueueManager;
    public ResetPasswordCommandHandle(
        UserManager<ApplicationUser> userManager,
        IFileHandler fileHandler,
        IMapper mapper,
        IMessageQueueManager messageQueueManager): base(userManager){
            _fileHandler = fileHandler;
            _mapper = mapper;
            _messageQueueManager = messageQueueManager;
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

        _messageQueueManager.UpdateUser(_mapper.Map<ApplicationUserResponse>(user)); 
        return (
            new AuthenticationResult{
                Message = "Profile picture have been successfully changed"});
   }
}