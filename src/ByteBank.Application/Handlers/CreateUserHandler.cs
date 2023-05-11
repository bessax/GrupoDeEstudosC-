using Microsoft.AspNetCore.Identity;

namespace ByteBank.Application.Handlers;

public class CreateUserHandler
    : IRequestHandler<CreateUser, Result>
{
    private readonly UserManager<IdentityUser> _userManager;

    public CreateUserHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var user = new IdentityUser(request.Email)
        {
            UserName = request.UserName,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        return result.Succeeded
            ? Result.Ok()
            : Result.Fail(
            new ConflictError(
                result.Errors.Select(
                    e => new ConflictError.ConflictErrorItem(e.Code, e.Description))));
    }
}