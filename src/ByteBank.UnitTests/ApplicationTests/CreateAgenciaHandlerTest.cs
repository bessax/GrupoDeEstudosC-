namespace ByteBank.UnitTests.ApplicationTests;

public class CreateAgenciaHandlerTest
{
    private readonly Mock<IAgenciaRepository> _repositoryMock;
    private readonly IRequestHandler<CreateAgencia, Result<CreateAgenciaResultValue>> _handler;

    public CreateAgenciaHandlerTest()
    {
        _repositoryMock = new Mock<IAgenciaRepository>();
        _handler = new CreateAgenciaHandler(_repositoryMock.Object);

        _repositoryMock.Setup(r => r.UnitOfWork.CommitAsync());
    }

    [Fact]
    public async Task Handle_DeveAdicionarAgencia()
    {
        // Arrange
        var request = new CreateAgencia(
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");

        // Act
        var result = await _handler.Handle(
            request,
            CancellationToken.None);

        // Assert
        _repositoryMock.Verify(
            r => r.Add(
                It.Is<Agencia>(
                    a => a.Nome == request.Nome &&
                        a.Endereco.Logradouro == request.Logradouro &&
                        a.Endereco.Cep == request.Cep &&
                        a.Endereco.Numero == request.Numero &&
                        a.Endereco.Complemento == request.Complemento)),
            Times.Once);
    }

    [Fact]
    public async Task Handle_DeveCommitarTransacao()
    {
        // Arrange
        var request = new CreateAgencia(
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");

        // Act
        var result = await _handler.Handle(
            request,
            CancellationToken.None);

        // Assert
        _repositoryMock.Verify(
            r => r.UnitOfWork.CommitAsync(),
            Times.Once);
    }

    [Fact]
    public async Task Handle_DeveRetornarSucesso()
    {
        // Arrange
        var request = new CreateAgencia(
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");

        // Act
        var result = await _handler.Handle(
            request,
            CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeSuccess();
    }

    [Fact]
    public async Task Handle_DeveRetornarValorCriado()
    {
        // Arrange
        var request = new CreateAgencia(
            "Agencia 1",
            "Rua 1",
            "12345678",
            123,
            "Complemento 1");

        // Act
        var result = await _handler.Handle(
            request,
            CancellationToken.None);

        // Assert
        result.Value.Should().NotBeNull();
        result.Value.Nome.Should().Be(request.Nome);
        result.Value.Logradouro.Should().Be(request.Logradouro);
        result.Value.Cep.Should().Be(request.Cep);
        result.Value.Numero.Should().Be(request.Numero);
        result.Value.Complemento.Should().Be(request.Complemento);
    }
}