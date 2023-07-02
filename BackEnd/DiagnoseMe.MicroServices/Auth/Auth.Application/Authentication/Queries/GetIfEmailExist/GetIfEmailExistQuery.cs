namespace Auth.Application.Authentication.Queries.GetIfEmailExist;

public record GetIfEmailExistQuery(
    string Email) : IRequest<bool>;