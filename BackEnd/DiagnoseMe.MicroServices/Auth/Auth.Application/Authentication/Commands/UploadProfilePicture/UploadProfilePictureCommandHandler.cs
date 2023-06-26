using Auth.Application.Authentication.Helpers;
using Auth.Application.Common.Interfaces.RabbitMQ;
using MapsterMapper;

namespace Auth.Application.Authentication.Commands.UploadProfilePicture;

public class ResetPasswordCommandHandle :
    BaseAuthenticationHandler,
    IRequestHandler<UploadProfilePictureCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IMapper _mapper;
    private readonly IMessageQueueManager _messageQueueManager;
    public ResetPasswordCommandHandle(
        UserManager<ApplicationUser> userManager,
        IMapper mapper,
        IMessageQueueManager messageQueueManager): base(userManager){
            _mapper = mapper;
            _messageQueueManager = messageQueueManager;
        }
    public async Task<ErrorOr<AuthenticationResult>> Handle(UploadProfilePictureCommand command, CancellationToken cancellationToken)
    {


            
        var user = await _userManager.FindByNameAsync(command.UserName);
        if (user == null)
            return (Errors.User.Name.NotExists);
        var result = FileConverter.ConvertToPng(
            command.Base64Picture);  
        if (result.IsError)
            return (result.Errors);
                
        user!.ProfilePictureUrl = Path.Combine(StaticPaths.ProfilePicturesPath, result.Value.Name);
        var updateResult = await _userManager.UpdateAsync(user);

        _messageQueueManager.UpdateUser(_mapper.Map<ApplicationUserResponse>(user)); 
        _messageQueueManager.PublishFile(new List<RMQFileResponse>(){
             new RMQFileResponse(
                FilePath: StaticPaths.ProfilePicturesPath,
                File: result.Value)
        });
        return (
            new AuthenticationResult{
                Message = "Profile picture have been successfully changed"});
   }
}