namespace ByteBank.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class AgenciasController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public AgenciasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAgenciasByPage(
        int pageNumber = 1,
        int pageSize = 10)
    {
        var result = await _mediator.Send(
            new GetAgenciasByPage(
                pageNumber,
                pageSize));

        return (result.IsSuccess) ?
            Ok(result.Value) :
            HandleFailure(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAgenciaById(int id)
    {
        var result = await _mediator.Send(
            new GetAgenciaById(id));

        return (result.IsSuccess) ?
            Ok(result.Value) :
            HandleFailure(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAgencia(CreateAgencia request)
    {
        var result = await _mediator.Send(request);

        return (result.IsSuccess) ?
            Ok(result.Value) :
            HandleFailure(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAgencia(UpdateAgencia request)
    {
        var result = await _mediator.Send(request);

        return (result.IsSuccess) ?
            Ok(result.Value) :
            HandleFailure(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAgencia(DeleteAgencia request)
    {
        var result = await _mediator.Send(request);

        return (result.IsSuccess) ?
            Ok(result.Value) :
            HandleFailure(result);
    }

    private IActionResult HandleFailure<TValue>(Result<TValue> result)
    {
        if (result.HasError<ResourceNotFoundError>())
        {
            return NotFound();
        }

        if (result.HasError<ValidationError>(
            out IEnumerable<ValidationError> validationErrors))
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