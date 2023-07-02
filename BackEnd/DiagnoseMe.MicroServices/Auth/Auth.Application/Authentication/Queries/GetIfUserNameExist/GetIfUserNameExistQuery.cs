namespace Auth.Application.Authentication.Queries.GetIfUsernameExist;

public record GetIfUsernameExistQuery(
    string Username) : IRequest<bool>;