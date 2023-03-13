namespace Auth.Application.Authentication.Commands.UploadProfilePicture;

public record UploadProfilePictureCommand(
    string Base64Picture,
    string UserName) : IRequest<ErrorOr<AuthenticationResult>>;