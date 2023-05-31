namespace ByteBank.UnitTests.ApplicationTests;

public class GetAgenciaByIdHandlerTest
{
    private readonly Mock<IAgenciaRepository> _repositoryMock;
    private readonly IRequestHandler<GetAgenciaById, Result<GetAgenciaByIdResultValue>> _handler;

    public GetAgenciaByIdHandlerTest()
    {
        _repositoryMock = new Mock<IAgenciaRepository>();
        _handler = new GetAgenciaByIdHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ComIdValido_DeveRetornarSucesso()
    {
        // Arrange
        var request = new GetAgenciaById(1);
        _repositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(
                new Agencia(
                    "Agencia 1",
                    new Endereco(
                        "Rua 1",
                        "12345678",
                        123,
                        "Complemento 1")));

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeSuccess();
    }

    [Fact]
    public async Task Handle_ComIdValido_DeveRetornarValor()
    {
        // Arrange
        var request = new GetAgenciaById(1);
        _repositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(
                new Agencia(
                    "Agencia 1",
                    new Endereco(
                        "Rua 1",
                        "12345678",
                        123,
                        "Complemento 1")));

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().NotBeNull();
        result.Value.Nome.Should().Be("Agencia 1");
        result.Value.Logradouro.Should().Be("Rua 1");
        result.Value.Cep.Should().Be("12345678");
        result.Value.Numero.Should().Be(123);
        result.Value.Complemento.Should().Be("Complemento 1");
    }

    [Fact]
    public async Task Handle_QuandoNaoEncontrarAgencia_DeveRetornarFalha()
    {
        // Arrange
        var request = new GetAgenciaById(1);
        _repositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Agencia?)null);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeFailure();
    }
}