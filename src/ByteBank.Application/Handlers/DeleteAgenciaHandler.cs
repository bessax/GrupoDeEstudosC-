namespace ByteBank.Application.Handlers;

public class DeleteAgenciaHandler
    : IRequestHandler<DeleteAgencia, Result<DeleteAgenciaResultValue>>
{
    private readonly IAgenciaRepository _repository;

    public DeleteAgenciaHandler(IAgenciaRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result<DeleteAgenciaResultValue>> Handle(
        DeleteAgencia request,
        CancellationToken cancellationToken)
    {
        var agencia = await _repository.GetById(request.Id);

        if (agencia is null)
        {
            return Result.Fail(
                new ResourceNotFoundError(
                    $"Agencia with id {request.Id} not found."));
        }

        _repository.Delete(agencia);
        await _repository.UnitOfWork.CommitAsync();

        return Result.Ok(
            new DeleteAgenciaResultValue(
                agencia.Id,
                agencia.Nome,
                agencia.Endereco.Logradouro,
                agencia.Endereco.Cep,
                agencia.Endereco.Numero,
                agencia.Endereco.Complemento));
    }
}