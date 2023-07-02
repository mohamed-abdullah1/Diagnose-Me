using ErrorOr;

namespace Auth.Application.Authentication.Queries.GetUser;


public record GetUserQuery(
    string UserId) : IRequest<ErrorOr<ApplicationUserResponse>>;