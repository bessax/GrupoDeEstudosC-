namespace ByteBank.Application.Handlers;

public class UpdateAgenciaHandler
    : IRequestHandler<UpdateAgencia, Result<UpdateAgenciaResultValue>>
{
    private readonly IAgenciaRepository _repository;

    public UpdateAgenciaHandler(IAgenciaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<UpdateAgenciaResultValue>> Handle(
        UpdateAgencia request,
        CancellationToken cancellationToken)
    {
        var agencia = await _repository.GetById(request.Id);

        if (agencia is null)
        {
            return Result.Fail(
                new ResourceNotFoundError(
                    $"Agencia with id {request.Id} not found."));
        }

        agencia.UpdateNome(request.Nome);
        agencia.Endereco.UpdateLogradouro(request.Logradouro);
        agencia.Endereco.UpdateCep(request.Cep);
        agencia.Endereco.UpdateNumero(request.Numero);
        agencia.Endereco.UpdateComplemento(request.Complemento);
        await _repository.UnitOfWork.CommitAsync();

        return Result.Ok(
            new UpdateAgenciaResultValue(
                agencia.Id,
                agencia.Nome,
                agencia.Endereco.Logradouro,
                agencia.Endereco.Cep,
                agencia.Endereco.Numero,
                agencia.Endereco.Complemento));
    }
}