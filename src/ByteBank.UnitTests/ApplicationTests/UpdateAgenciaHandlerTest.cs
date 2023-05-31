namespace ByteBank.UnitTests.ApplicationTests;

public class UpdateAgenciaHandlerTest
{
    private readonly Mock<IAgenciaRepository> _repositoryMock;
    private readonly IRequestHandler<UpdateAgencia, Result<UpdateAgenciaResultValue>> _handler;

    public UpdateAgenciaHandlerTest()
    {
        _repositoryMock = new Mock<IAgenciaRepository>();
        _handler = new UpdateAgenciaHandler(_repositoryMock.Object);

        _repositoryMock.Setup(r => r.UnitOfWork.CommitAsync());
    }

    [Fact]
    public async Task Handle_DeveChamarGetByIdAsync()
    {
        // Arrange
        var id = 1;
        var request = new UpdateAgencia(
            id,
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(request, cancellationToken);

        // Assert
        _repositoryMock.Verify(
            r => r.GetByIdAsync(id),
            Times.Once);
    }

    [Fact]
    public async Task Handle_DeveCommitarTransacao()
    {
        // Arrange
        var id = 1;
        var request = new UpdateAgencia(
            id,
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");
        var cancellationToken = CancellationToken.None;
        _repositoryMock.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(new Agencia(
                "Agencia 1",
                new Endereco(
                    "Rua 1",
                    "12345678",
                    123,
                    "Complemento 1")));

        // Act
        var result = await _handler.Handle(request, cancellationToken);

        // Assert
        _repositoryMock.Verify(
            r => r.UnitOfWork.CommitAsync(),
            Times.Once);
    }

    [Fact]
    public async Task Handle_DeveRetornarSucesso()
    {
        // Arrange
        var id = 1;
        var request = new UpdateAgencia(
            id,
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");
        var cancellationToken = CancellationToken.None;
        _repositoryMock.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(new Agencia(
                "Agencia 1",
                new Endereco(
                    "Rua 1",
                    "12345678",
                    123,
                    "Complemento 1")));

        // Act
        var result = await _handler.Handle(request, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeSuccess();
    }

    [Fact]
    public async Task Handle_ComAgenciaNaoEncontrada_DeveRetornarFalha()
    {
        // Arrange
        var id = 1;
        var request = new UpdateAgencia(
            id,
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");
        var cancellationToken = CancellationToken.None;
        _repositoryMock.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync((Agencia?)null);

        // Act
        var result = await _handler.Handle(request, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeFailure();
    }

    [Fact]
    public async Task Handle_ComAgenciaEncontrada_DeveAtualizarAgencia()
    {
        // Arrange
        var id = 1;
        var request = new UpdateAgencia(
            id,
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");
        var cancellationToken = CancellationToken.None;
        var agencia = new Agencia(
            "Agencia 1",
            new Endereco(
                "Rua 1",
                "12345678",
                123,
                "Complemento 1"));
        _repositoryMock.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(agencia);

        // Act
        var result = await _handler.Handle(request, cancellationToken);

        // Assert
        agencia.Nome.Should().Be(request.Nome);
        agencia.Endereco.Logradouro.Should().Be(request.Logradouro);
        agencia.Endereco.Cep.Should().Be(request.Cep);
        agencia.Endereco.Numero.Should().Be(request.Numero);
        agencia.Endereco.Complemento.Should().Be(request.Complemento);
    }

    [Fact]
    public async Task Handle_ComAgenciaEncontrada_DeveRetornarAgenciaAtualizada()
    {
        // Arrange
        var id = 1;
        var request = new UpdateAgencia(
            id,
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");
        var cancellationToken = CancellationToken.None;
        var agencia = new Agencia(
            "Agencia 1",
            new Endereco(
                "Rua 1",
                "12345678",
                123,
                "Complemento 1"));
        _repositoryMock.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(agencia);

        // Act
        var result = await _handler.Handle(request, cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeSuccess();
        result.Value.Should().NotBeNull();
        result.Value.Id.Should().Be(agencia.Id);
        result.Value.Nome.Should().Be(agencia.Nome);
        result.Value.Logradouro.Should().Be(agencia.Endereco.Logradouro);
        result.Value.Cep.Should().Be(agencia.Endereco.Cep);
        result.Value.Numero.Should().Be(agencia.Endereco.Numero);
        result.Value.Complemento.Should().Be(agencia.Endereco.Complemento);
    }
}