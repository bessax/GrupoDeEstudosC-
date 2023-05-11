namespace ByteBank.Application.Handlers;

public class GetAgenciasHandler
    : IRequestHandler<GetAgencias, Result<GetAgenciasResultValue>>
{
    private readonly IAgenciaRepository _repository;

    public GetAgenciasHandler(IAgenciaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetAgenciasResultValue>> Handle(
        GetAgencias request,
        CancellationToken cancellationToken)
    {
        var agencias = await _repository.GetAllAsync();

        return Result.Ok(
            new GetAgenciasResultValue(
                agencias.Select(
                    a => new GetAgenciasResultValueItem(
                        a.Id,
                        a.Nome,
                        a.Endereco.Logradouro,
                        a.Endereco.Cep,
                        a.Endereco.Numero,
                        a.Endereco.Complemento))));
    }
}