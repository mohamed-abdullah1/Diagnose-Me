using Auth.Application.Common.Interfaces.RabbitMq;
using MapsterMapper;

namespace Auth.Application.Authentication.Commands.DeleteAccount;

public class DeleteAccountCommandHandler : 
    BaseAuthenticationHandler,
    IRequestHandler<DeleteAccountCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IMessageQueueManager _messageQueueManager;

    public DeleteAccountCommandHandler(
        UserManager<ApplicationUser> userManager,
        IMessageQueueManager messageQueueManager): base(userManager)
    {
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(command.UserId);
        if(user == null)
            return Errors.User.Name.NotExists;
        
        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
            return Errors.User.MapIdentityError(result.Errors.ToList());
        
        _messageQueueManager.DeleteUser(command.UserId);
        return new AuthenticationResult
        {
            Message = "Your account is successfully deleted"
        };

    }
}