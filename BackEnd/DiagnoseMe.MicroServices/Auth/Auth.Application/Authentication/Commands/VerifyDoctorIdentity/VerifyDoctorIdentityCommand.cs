namespace Auth.Application.Authentication.Commands.VerifyDoctorIdentity;

public record VerifyDoctorIdentityCommand(
    string UserName,
    string Base64License
) : IRequest<ErrorOr<AuthenticationResult>>;