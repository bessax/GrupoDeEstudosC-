namespace ByteBank.UnitTests.Application;

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
        var request = new GetAgencias();
        _repositoryMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(
                new List<Agencia>
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

        var result = await _handler.Handle(request, CancellationToken.None);

        result.Should().NotBeNull();
        result.Should().BeSuccess();
    }

    [Fact]
    public async Task Handle_DeveRetornarValor()
    {
        var request = new GetAgencias();
        _repositoryMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(
                new List<Agencia>
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

        var result = await _handler.Handle(request, CancellationToken.None);

        result.Should().NotBeNull();
        result.Value.Should().NotBeNull();
        result.Value.Items.Should().NotBeNull();
        result.Value.Items.Should().HaveCount(2);
        result.Value.Items.Should().Contain(x => x.Nome == "Agencia 1");
        result.Value.Items.Should().Contain(x => x.Nome == "Agencia 2");
    }
}