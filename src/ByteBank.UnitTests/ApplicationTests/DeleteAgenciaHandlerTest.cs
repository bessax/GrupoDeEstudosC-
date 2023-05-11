namespace ByteBank.UnitTests.ApplicationTests;

public class DeleteAgenciaHandlerTest
{
    private readonly Mock<IAgenciaRepository> _repositoryMock;
    private readonly IRequestHandler<DeleteAgencia, Result<DeleteAgenciaResultValue>> _handler;

    public DeleteAgenciaHandlerTest()
    {
        _repositoryMock = new Mock<IAgenciaRepository>();
        _handler = new DeleteAgenciaHandler(_repositoryMock.Object);

        _repositoryMock.Setup(r => r.UnitOfWork.CommitAsync());
    }

    [Fact]
    public async Task Handle_DeveChamarGetByIdAsync()
    {
        // Arrange
        var id = 1;
        var request = new DeleteAgencia(id);
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(request, cancellationToken);

        // Assert
        _repositoryMock.Verify(
            r => r.GetByIdAsync(id),
            Times.Once);
    }

    [Fact]
    public async Task Handle_DeveChamarDelete()
    {
        // Arrange
        var id = 1;
        var request = new DeleteAgencia(id);
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
            r => r.Delete(It.IsAny<Agencia>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_DeveCommitarTransacao()
    {
        // Arrange
        var id = 1;
        var request = new DeleteAgencia(id);
        var cancellationToken = CancellationToken.None;
        _repositoryMock.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(
                new Agencia(
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
        var request = new DeleteAgencia(id);
        var cancellationToken = CancellationToken.None;
        _repositoryMock.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(
                new Agencia(
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
    public async Task Handle_DeveRetornarValorDeletado()
    {
        // Arrange
        var id = 1;
        var request = new DeleteAgencia(id);
        var cancellationToken = CancellationToken.None;
        var nome = "Agencia 1";
        var endereco = new Endereco(
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");
        _repositoryMock.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(
                new Agencia(
                    nome,
                    endereco));

        // Act
        var result = await _handler.Handle(request, cancellationToken);

        // Assert
        result.Value.Should().NotBeNull();
        result.Value.Nome.Should().Be(nome);
        result.Value.Logradouro.Should().Be(endereco.Logradouro);
        result.Value.Cep.Should().Be(endereco.Cep);
        result.Value.Numero.Should().Be(endereco.Numero);
    }
}