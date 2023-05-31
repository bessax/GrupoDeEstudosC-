namespace ByteBank.UnitTests.ApplicationTests;

public class GetAllAgenciasHandlerTest
{
    private readonly Mock<IAgenciaRepository> _repositoryMock;
    private readonly IRequestHandler<GetAgencias, Result<GetAgenciasResultValue>> _handler;

    public GetAllAgenciasHandlerTest()
    {
        _repositoryMock = new Mock<IAgenciaRepository>();
        _handler = new GetAgenciasHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_DeveRetornarSucesso()
    {
        // Arrange
        var request = new GetAgencias();
        _repositoryMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(
                new[]
                {
                    new Agencia(
                        "Agencia 1",
                        new Endereco(
                            "Rua 1",
                            "12345678",
                            123,
                            "Complemento 1")),
                    new Agencia(
                        "Agencia 2",
                        new Endereco(
                            "Rua 2",
                            "12345678",
                            123,
                            "Complemento 2"))
                });

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeSuccess();
    }

    [Fact]
    public async Task Handle_DeveRetornarValor()
    {
        // Arrange
        var request = new GetAgencias();
        _repositoryMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(
                new[]
                {
                    new Agencia(
                        "Agencia 1",
                        new Endereco(
                            "Rua 1",
                            "12345678",
                            123,
                            "Complemento 1")),
                    new Agencia(
                        "Agencia 2",
                        new Endereco(
                            "Rua 2",
                            "12345678",
                            123,
                            "Complemento 2"))
                });

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().NotBeNull();
        result.Value.Items.Should().NotBeNull();
        result.Value.Items.Should().HaveCount(2);
        result.Value.Items.Should().Contain(x => x.Nome == "Agencia 1");
        result.Value.Items.Should().Contain(x => x.Nome == "Agencia 2");
    }
}