namespace ByteBank.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUser request)
    {
        var result = await _mediator.Send(request);

        return (result.IsSuccess) ?
            Ok() :
            HandleFailure(result);
    }

    // TODO: Queria melhorar isso, mas não sei como 🙃
    private IActionResult HandleFailure(Result result)
    {
        if (result.HasError<ConflictError>(out IEnumerable<ConflictError> conflictErrors))
        {
            foreach (var item in conflictErrors.SelectMany(e => e.Errors))
            {
                ModelState.AddModelError(item.Key, item.Message);
            }

            return Conflict(new ValidationProblemDetails(ModelState)
            {
                Title = "Conflict",
                Status = StatusCodes.Status409Conflict,
                Detail = "See the 'errors' property for details.",
                Instance = HttpContext.Request.Path
            });
        }

        if (result.HasError<ValidationError>(out IEnumerable<ValidationError> validationErrors))
        {
            foreach (var item in validationErrors.SelectMany(e => e.Errors))
            {
                ModelState.AddModelError(item.FieldName, item.ErrorMessage);
            }

            return ValidationProblem();
        }

        return BadRequest();
    }
}