namespace ByteBank.UnitTests.ApplicationTests;

public class GetAgenciasByPageHandlerTest
{
    private readonly Mock<IAgenciaRepository> _repositoryMock;
    private readonly IRequestHandler<GetAgenciasByPage, Result<GetAgenciasByPageResultValue>> _handler;

    public GetAgenciasByPageHandlerTest()
    {
        _repositoryMock = new Mock<IAgenciaRepository>();
        _handler = new GetAgenciasByPageHandler(_repositoryMock.Object);
    }

    [Fact]
    public async Task Handle_DeveRetornarSucesso()
    {
        // Arrange
        var pageNumber = 1;
        var pageSize = 10;
        var request = new GetAgenciasByPage(pageNumber, pageSize);
        _repositoryMock
            .Setup(x => x.GetByPageAsync(pageNumber, pageSize))
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
        var pageNumber = 1;
        var pageSize = 10;
        var request = new GetAgenciasByPage(pageNumber, pageSize);
        _repositoryMock
            .Setup(x => x.GetByPageAsync(pageNumber, pageSize))
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

    [Fact]
    public async Task Handle_QuandoNaoExistirAgencias_DeveRetornarSucesso()
    {
        // Arrange
        var request = new GetAgenciasByPage(1, 10);
        _repositoryMock
            .Setup(x => x.GetByPageAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(new List<Agencia>());

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeSuccess();
    }

    [Fact]
    public async Task Handle_QuandoNaoExistirAgencias_DeveRetornarVazio()
    {
        // Arrange
        var request = new GetAgenciasByPage(1, 10);
        _repositoryMock
            .Setup(x => x.GetByPageAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(new List<Agencia>());

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().NotBeNull();
        result.Value.Items.Should().NotBeNull();
        result.Value.Items.Should().HaveCount(0);
    }
}