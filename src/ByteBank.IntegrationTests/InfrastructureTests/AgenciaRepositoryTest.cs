namespace ByteBank.IntegrationTests.InfrastructureTests;

[Collection(nameof(DbContextCollection))]
public class AgenciaRepositoryTest : IClassFixture<AgenciaRepositoryFixture>
{
    private readonly AgenciaRepository _repository;
    private readonly ByteBankContext _context;

    public AgenciaRepositoryTest(AgenciaRepositoryFixture fixture)
    {
        _repository = fixture.Repository;
        _context = fixture.Context;
    }

    [Fact]
    public async Task GetAllAsync_DeveRetornarColecaoNaoNula()
    {
        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetByIdAsync_DeveRetornarAgenciaNaoNula()
    {
        // Arrange
        var id = 1;

        // Act
        var result = await _repository.GetByIdAsync(id);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetByIdAsync_DeveRetornarAgenciaComValores()
    {
        // Arrange
        var id = 1;

        // Act
        var result = await _repository.GetByIdAsync(id);

        // Assert
        result!.Id.Should().Be(id);
        result.Nome.Should().NotBeNullOrWhiteSpace();
        result.Endereco.Should().NotBeNull();
        result.Endereco.Logradouro.Should().NotBeNullOrWhiteSpace();
        result.Endereco.Cep.Should().NotBeNullOrWhiteSpace();
        result.Endereco.Numero.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task GetByIdAsync_QuandoNaoExistirAgencia_DeveRetornarNull()
    {
        // Arrange
        var id = int.MaxValue;

        // Act
        var result = await _repository.GetByIdAsync(id);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void Add_DeveAlterarEstadoParaAdicionado()
    {
        // Arrange
        var agencia = new Agencia(
            "Agencia 2",
            new Endereco(
                "Rua 1",
                "12345678",
                123,
                "Casa 1"));

        // Act
        _repository.Add(agencia);

        // Assert
        _context.Entry(agencia)
            .State
            .Should()
            .Be(EntityState.Added);
    }

    [Fact]
    public void Update_DeveAlterarEstadoParaModificado()
    {
        // Arrange
        var agencia = _repository.GetByIdAsync(1).Result;

        // Act
        agencia!.UpdateNome("Agencia 1 Alterada");

        // Assert
        _context.Entry(agencia)
            .State
            .Should()
            .Be(EntityState.Modified);
    }

    [Fact]
    public async Task Delete_DeveAlterarEstadoParaDeletado()
    {
        // Arrange
        var agencia = await _repository.GetByIdAsync(1);

        // Act
        _repository.Delete(agencia!);

        // Assert
        _context.Entry(agencia!)
            .State
            .Should()
            .Be(EntityState.Deleted);
    }
}