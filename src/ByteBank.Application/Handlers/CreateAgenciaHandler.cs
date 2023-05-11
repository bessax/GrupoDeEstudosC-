namespace ByteBank.Application.Handlers;

public class CreateAgenciaHandler
    : IRequestHandler<CreateAgencia, Result<CreateAgenciaResultValue>>
{
    private readonly IAgenciaRepository _repository;

    public CreateAgenciaHandler(IAgenciaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CreateAgenciaResultValue>> Handle(
        CreateAgencia request,
        CancellationToken cancellationToken)
    {
        var agencia = new Agencia(
            request.Nome,
            new Endereco(
                request.Logradouro,
                request.Cep,
                request.Numero,
                request.Complemento));

        _repository.Add(agencia);
        await _repository.UnitOfWork.CommitAsync();

        return Result.Ok(
            new CreateAgenciaResultValue(
                agencia.Id,
                agencia.Nome,
                agencia.Endereco.Logradouro,
                agencia.Endereco.Cep,
                agencia.Endereco.Numero,
                agencia.Endereco.Complemento));
    }
}