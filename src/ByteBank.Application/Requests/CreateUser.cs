namespace ByteBank.Application.Requests;

public record CreateUser(
    string UserName,
    string Email,
    string Password
) : IRequest<Result>;