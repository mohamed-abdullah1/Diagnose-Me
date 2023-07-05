namespace Auth.Application.Authentication.Commands.DeleteAccount;


public record DeleteAccountCommand(
    string UserId) : IRequest<ErrorOr<AuthenticationResult>>;