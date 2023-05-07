namespace ByteBank.Application.Handlers;

public class GetAgenciasByPageHandler
    : IRequestHandler<GetAgenciasByPage, Result<GetAgenciasByPageResultValue>>
{
    private readonly IAgenciaRepository _repository;

    public GetAgenciasByPageHandler(IAgenciaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetAgenciasByPageResultValue>> Handle(
        GetAgenciasByPage request,
        CancellationToken cancellationToken)
    {
        var agencias = await _repository.GetByPage(
            request.PageNumber,
            request.PageSize);

        return Result.Ok(
            new GetAgenciasByPageResultValue(
                agencias.Select(
                    a => new GetAgenciasByPageResultValueItem(
                        a.Id,
                        a.Nome,
                        a.Endereco.Logradouro,
                        a.Endereco.Cep,
                        a.Endereco.Numero,
                        a.Endereco.Complemento))));
    }
}