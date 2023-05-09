namespace ByteBank.Application.Handlers;

public class GetAgenciaByIdHandler
    : IRequestHandler<GetAgenciaById, Result<GetAgenciaByIdResultValue>>
{
    private readonly IAgenciaRepository _repository;

    public GetAgenciaByIdHandler(IAgenciaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetAgenciaByIdResultValue>> Handle(
        GetAgenciaById request,
        CancellationToken cancellationToken)
    {
        var agencia = await _repository.GetByIdAsync(request.Id);

        return agencia is null
            ? (Result<GetAgenciaByIdResultValue>)Result.Fail(
                new ResourceNotFoundError(
                    $"Agencia with id {request.Id} not found."))
            : Result.Ok(
            new GetAgenciaByIdResultValue(
                agencia.Id,
                agencia.Nome,
                agencia.Endereco.Logradouro,
                agencia.Endereco.Cep,
                agencia.Endereco.Numero,
                agencia.Endereco.Complemento));
    }
}